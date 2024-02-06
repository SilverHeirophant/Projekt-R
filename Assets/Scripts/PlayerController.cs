using System;
using UnityEngine;
using System.Collections;
{
    public class PlayerController : MonoBehaviour
    {

        public float horizontalInput;
        public float verticalInput;
        public int speed;
        public int boost;
    
    //Health Bar thingies
    public int maxHealth;
    public int currentHealth;
    public Health HBar;

    //Boost Thingies
    public int maxBoost;
    public float currentBoost;
    public Boost BBar;

    [SerializeField] GameObject Dialogue;
    
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;

    //public PingDirection pingDirection;

    //Transforms
    public GameObject bulletPrefab;
    Vector3 lookDirection;
    
    public float throwforce;

    //Private variables
    private BulletBehavior bulletBehavior;
    private Rigidbody playerRb;
    private Quaternion targetRotation;

        void Awake()
        {
        Time.timeScale = 0;
        playerRb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            //Starts the game with both sliders fully loaded
            currentHealth = maxHealth;
            currentBoost = maxBoost;
            HBar.SetMaxHealth(maxHealth);
            BBar.SetMaxBoost(maxBoost);
            //pingDirection = gameObject.GetComponent<PingDetection>();

            Dialogue.SetActive(true);
            MainHUD.SetActive(false);
            MissionComplete.SetActive(false);

            targetRotation = transform.rotation;
            
            m_Rigidbody = GetComponent<Rigidbody>();
            // Store original drag settings, these are modified during flight.
            m_OriginalDrag = m_Rigidbody.drag;
            m_OriginalAngularDrag = m_Rigidbody.angularDrag;

			for (int i = 0; i < transform.childCount; i++ )
			{
				foreach (var componentsInChild in transform.GetChild(i).GetComponentsInChildren<WheelCollider>())
				{
					componentsInChild.motorTorque = 0.18f;
				}
			}
        }

        void Update()
        {
        //Establishing wasd movement
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
            
            //If the player presses shift, they will receive a "boost". It only adds 5 to the current speed
        if (Input.GetButtonDown("Fire3"))
        {
            speed = speed + boost;
            
            StartCoroutine(WaitAfterBoost(0.2f));
            SpentBoost(0.1f);
        }
        
        if (Input.GetButtonUp("Fire3"))
        {
            speed = 30;
            AddBoost(maxBoost);
        }
        

        //Testing the healthbar xd
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dialogue.SetActive(false);

            Time.timeScale = 1;
            MainHUD.SetActive(true);
        }
        }

        void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HBar.SetHealth(currentHealth);
    }
    
    void SpentBoost(float ridBoost)
    {
        currentBoost -= ridBoost;
        BBar.SetBoost((int)currentBoost);
    }
    
    void AddBoost(int addBoost)
    {
        currentBoost += addBoost;
        BBar.SetBoost((int)currentBoost);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Rings"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    
        if (collision.gameObject.CompareTag("Ping"))
        {
            Time.timeScale = 0;
            
            MissionComplete.SetActive(true);
            MainHUD.SetActive(false);
            Dialogue.SetActive(false);
        }
    
    }

    public IEnumerator WaitAfterBoost(float delay)
    {
        while (Input.GetButtonDown("Fire3"))
        {
            currentBoost--;
            yield return new WaitForSeconds(delay);
        }
    }
    
    public IEnumerator GetBoost(float value)
    {
        while (Input.GetButtonUp("Fire3"))
        {
            AddBoost(maxBoost);
            yield return new WaitForSeconds(10);
        }
    }

}


