using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float horizontalInput;
    public float verticalInput;
    public int speed = 5;
    public GameObject bulletPrefab;
    Vector3 lookDirection;
    private BulletBehavior bulletBehavior;
    
    //Private variables
    private float postilt = 25;
    private float negTilt = -25;
    //private float turnWait = 1.0f;
    
    
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
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
    
        
        /*
        
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
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ring"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }


}


