using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float maxZ = 450f;
    public float minZ = 120f;
    public lvl2PC playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<lvl2PC>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);
        transform.position = currentPosition;

    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Confirmed hit!");
        }

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            Destroy(gameObject);
            
            //playerScript.TakeDamage(5);
        }
    }


}
