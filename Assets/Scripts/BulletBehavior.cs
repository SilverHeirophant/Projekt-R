using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletBehavior : MonoBehaviour
{
//Bulleto :)
    public GameObject bullet;
    public float shootForce;
    public float upwardForce;

//Ship Gun variables
    public float timeBetweenShots;
    public float spread;
    public float reloadTime;
    public float timeBetweenShooting;
    
//ints used
    public int magazineSize;
    public int bulletsPerTap;
    public int bulletsLeft;
    public int bulletsShot;

//Bools used
    public bool allowButtonHold;
    public bool shooting;
    public bool readyToShoot;
    public bool reloading;

    private void Awake()
    {
        //Check for the magazine. ie; how full it is
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    void Update()
    {
        PlayerInput();
    }
    
    private void PlayerInput()
    {
        //Check if player is allowed to hold down ;v
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.F);
        }
    
        else
        {
            shooting = Input.GetKeyDown(KeyCode.F);
        }
    
    //Shooting Logic
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }
    
    
    }

    private void Shoot()
    {
        readyToShoot = false;
        bulletsLeft--;
        bulletsShot++;
    }


}
