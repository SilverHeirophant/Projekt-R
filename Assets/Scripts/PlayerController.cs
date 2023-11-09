using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public int speed = 5;
    
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb = GetComponent<Rigidbody>();
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Movement imputs. Up allows it to move forwards constantly. Intentional. Forward allows it to move up and down and left allows it to move left and right.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.left * verticalInput * speed * Time.deltaTime);
    
        float z = horizontalInput;
        Vector3 euler = transform.localEulerAngles;
        euler.z = Mathf.Lerp(euler.z, z, 2.0f * Time.deltaTime);
        transform.localEulerAngles = euler;
    
    }
}
