using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    //Movement variables
    public float horizontalInput;
    public float verticalInput;
    public int speed = 25;
    public int boost = 5;
    
    //Health Bar thingies
    public int maxHealth;
    public int currentHealth;
    public Health HBar;

    //Boost Thingies
    public int maxBoost;
    public int currentBoost;
    public Boost BBar;

    //Transforms
    public GameObject bulletPrefab;
    Vector3 lookDirection;
    
    
    //Private variables
    private BulletBehavior bulletBehavior;
    private Rigidbody playerRb;

    //Holdon
    //private float postilt = 25;
    //private float negTilt = -25;
    //private float turnWait = 1.0f;
    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Starts the game with both sliders fully loaded
        currentHealth = maxHealth;
        currentBoost = maxBoost;
        HBar.SetMaxHealth(maxHealth);
        BBar.SetMaxBoost(maxBoost);
    }

    // Update is called once per frame
    void Update()
    {
        playerRb = GetComponent<Rigidbody>();

        //Establishing wasd movement
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Movement inputs. Up allows it to move forwards constantly. Intentional. Forward allows it to move up and down and left allows it to move left and right.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.left * verticalInput * speed * Time.deltaTime);
    
        //If the player presses shift, they will receive a "boost". It only adds 5 to the current speed
        if (Input.GetButton("Fire3"))
        {
            StartCoroutine(WaitAfterBoost(0.2f));
            SpentBoost(10);

        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed = speed - boost;
        }
        
        
        /* Work in progress honestly
        //Makes the player ship tilt on horizontal input value > 0 or < 0
        if (horizontalInput > 0)
        {
            transform.Rotate(Vector3.up * negTilt * Time.deltaTime, Space.Self);
            transform.Rotate(Vector3.up * 25 * Time.deltaTime, Space.World);
            //Debug.Log("turning right");

            Quaternion target = Quaternion.Euler(transform.rotation.x, 90, 90);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnWait * Time.deltaTime);
        }

        if (horizontalInput < 0)
        {
            transform.Rotate(Vector3.up * postilt * Time.deltaTime, Space.Self);
            transform.Rotate(Vector3.up * -25 * Time.deltaTime, Space.World);
            //Debug.Log("turning left");

            Quaternion target = Quaternion.Euler(transform.rotation.x, 90, 90);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnWait * Time.deltaTime);
        
        }
        */
        

        //Testing the healthbar xd
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }

    }
    //also testing the health bar :p
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HBar.SetHealth(currentHealth);
    }
    
    void SpentBoost(int ridBoost)
    {
        currentBoost -= ridBoost;
        BBar.SetBoost(currentBoost);
    }
    
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Rings"))
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

}


