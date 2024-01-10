using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int speed;
    public int maxHealth;
    public int currentHealth;

    //Future Suggestions
    public Health HP;
    public GameObject bulletPrefab;

    private Rigidbody rigidbody;
    private bool playerDetection;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                playerDetection = true;
            }
        }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletDamage(20);
            Debug.Log("Confirmed hit!");
        }
    }

    void BulletDamage(int damage)
    {
        currentHealth -= damage;
        HP.SetHealth(currentHealth);
    }

}
