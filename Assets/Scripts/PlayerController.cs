using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    public float horizontalInput;
    public float verticalInput;
    public int speed;
    public int maxHealth;
    public int currentHealth;
    public float timeInvincible = 2.0f;

    //Private Variables
    private Rigidbody playerRb;
    private float boost;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    if(Input.GetButtonDown("Jump"))
    {
        speed = speed + boost;
        
        if(speed > 15)
        {
            boost = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
