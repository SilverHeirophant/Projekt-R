using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyBehavior : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int maxHealth;
    public int currentHealth;
    public Transform firePoint;
    public float bulletForce;
    public float fireRate;
    public float fireElapsed;

    [SerializeField] GameObject particleEffect;
    
    //Future Suggestions
    public EnemiHP HP;
    public GameObject bulletPrefab;

    public Rigidbody rigidbody;
    public float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        HP = GetComponent<EnemiHP>();
        

        currentHealth = maxHealth;
        particleEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fireElapsed += Time.deltaTime;
         //delay = Random.Range(2, 8);

        if (fireElapsed >= delay)
        {
            fireElapsed = 0;
            Shoot();
        }

    
    }

    void Shoot()
    {
        //Spawn the bullet in front of the enemi plane
        bulletPrefab = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRB = bulletPrefab.GetComponent<Rigidbody>();

        bulletRB.velocity = firePoint.forward * bulletForce;

    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletDamage(10);
            Health();
        }
        
    }


    void BulletDamage(int damage)
    {
        currentHealth -= damage;
        particleEffect.SetActive(true);
        

        //HP.SetHealth(currentHealth);
    }

    void Health()
    {
        if (currentHealth <= 0)
        {
            scoreManager.IncreaseScore(1);
            Destroy(gameObject);
            
        }
    }

}
