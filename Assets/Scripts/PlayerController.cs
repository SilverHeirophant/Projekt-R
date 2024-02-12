using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    //Movement variables
    public float horizontalInput;
    public float verticalInput;
    public float smooth = 1f;
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
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Movement inputs. Up allows it to move forwards constantly. Intentional. Forward allows it to move up and down and left allows it to move left and right.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        //Makes the player ship tilt on horizontal input value > 0 or < 0
        if (horizontalInput > 0)
        {
            playerRb.AddRelativeTorque(Vector3.up * negTilt * Time.deltaTime);
            //transform.Rotate(Vector3.up * 25 * Time.deltaTime, Space.World);
            //Debug.Log("turning right");

            Quaternion target = Quaternion.Euler(transform.rotation.x, 90, 90);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnWait * Time.deltaTime);

            if(verticalInput > 0){
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

        }

        else if (horizontalInput < 0)
        {
            playerRb.AddRelativeTorque(Vector3.up * postilt * Time.deltaTime);
            //transform.Rotate(Vector3.up * -25 * Time.deltaTime, Space.World);
            //Debug.Log("turning left");

            Quaternion target = Quaternion.Euler(transform.rotation.x, 90, 90);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnWait * Time.deltaTime);
        }

        
        
        /*
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.left * verticalInput * speed * Time.deltaTime);

        */
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

    private System.Collections.IEnumerator AnimateRotationTowards(Transform target, Quaternion rot, float dur){
        float t = 0f;
        Quaternion start = target.rotation;
        while(t < dur){
            target.rotation = Quaternion.Slerp(start, rot, t / dur);
            yield return null;
            t += Time.deltaTime;
        }
    
        target.rotation = rot;
    }

    /*
    private void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            bulletPrefab = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            
            Rigidbody bulletPrefab = bulletPrefab.GetComponent<Rigidbody>();
            bulletPrefab.AddForce(throwforce * Vector3.forward, ForceMode.Impulse);

        }
    }
*/

}


