using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2PC : MonoBehaviour
{
    //Public variables
    //Movement variables
    public float horizontalInput;
    public float verticalInput;
    public float smooth = 1f;
    public int speed;
    public int boost;
    public ScoreManager scoreManager;
    
    //Health Bar thingies
    public int maxHealth;
    public int currentHealth;
    public Health HBar;

    //Boost Thingies
    public int maxBoost;
    public float currentBoost;
    public Boost BBar;
    public AudioClip fireBullet;
    public AudioClip Complete;

    [SerializeField] GameObject Dialogue;
    
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;

    //Used to restrict the player from these bounds when fighting the enemies
    public float minX = 1222f;
    public float maxX = 1341f;

    //Transforms
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    //Animations
    public Animator playerAnim;
    public enum playerStates {Default, tiltRight, tiltLeft, tiltUp, tiltDown}


    //Private variables
    //private BulletBehavior bulletBehavior;
    private Rigidbody playerRb;
    private Quaternion targetRotation;

    //Holdon
    private float postilt = 45;
    private float negTilt = -45;
    private float turnWait = 1.0f;
    
    void Awake()
    {
        Time.timeScale = 0;
        playerRb = GetComponent<Rigidbody>();

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = fireBullet;

        playerAnim = GetComponent<Animator>();
    }

    void Start()
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
    }


    // Update is called once per frame
    void Update()
    {
        //Establishing wasd movement
        horizontalInput = Input.GetAxis("Horizontal");

        // On this very specific script, the background moves not the player ;p
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);

        //If conditions for the animations
        if (horizontalInput < 0){
            playerAnim.SetBool("tiltLeft", true);
            playerAnim.SetBool("tiltRight", false);
        }
        else if (horizontalInput > 0){
            playerAnim.SetBool("tiltRight", true);
            playerAnim.SetBool("tiltLeft", false);
        }

        if (verticalInput > 0){
            playerAnim.SetBool("tiltUp", true);
            playerAnim.SetBool("tiltDown", false);
        }
        else if (verticalInput < 0){
            playerAnim.SetBool("tiltDown", true);
            playerAnim.SetBool("tiltUp", false);
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        transform.position = currentPosition;


        if (Input.GetKeyDown(KeyCode.F)){
            
            ShootBullet();
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            targetRotation *= Quaternion.AngleAxis(15, Vector3.left);
        }
    
        if (Input.GetKeyDown(KeyCode.L))
        {
            targetRotation *= Quaternion.AngleAxis(15, Vector3.right);
        }
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

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
    //also testing the health bar :p
    public void TakeDamage(int damage)
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
        if(collision.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(collision.gameObject);
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


    
    private void ShootBullet()
    {
        bulletPrefab = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bulletPrefab.GetComponent<Rigidbody>();
            
        bulletRb.velocity = firePoint.up * bulletSpeed;

        GetComponent<AudioSource>().Play();
    }




}
