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
    public float bulletForce = 15f;
    public float fireRate = 1f;

    [SerializeField] GameObject particleEffect;
    
    //Future Suggestions
    public EnemiHP HP;
    public GameObject bulletPrefab;

    public Rigidbody rigidbody;
    private float nextFireTime;
    
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
        if(Time.time >= nextFireTime){
            Shoot();

            nextFireTime = Time.time + 5f / fireRate;
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
            BulletDamage(30);
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
