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
    public float currentBoost;
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
            SpentBoost(0.1f);

        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed = speed - boost;
            //StartCoroutine(GetBoost(2));
        }
        

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
    
    void SpentBoost(float ridBoost)
    {
        currentBoost -= ridBoost;
        BBar.SetBoost((int)currentBoost);
    }
    
    void AddBoost(float addBoost)
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
            AddBoost(5);
            yield return new WaitForSeconds(value);
        }
    }
    
}


