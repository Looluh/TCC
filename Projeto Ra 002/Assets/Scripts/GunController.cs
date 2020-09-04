using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    public float shotTimer;

    public Transform firePoint;
    //public GunController theGun;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (shotTimer > 0)
        {
            shotTimer -= Time.deltaTime;
        }

        if (isFiring)
        {
            if (shotTimer <= 0)
            {
                shotTimer = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.speed = bulletSpeed;
            }
        }
        /*else
            shotCounter = 0;//se tirar essa linha o player sempre vai obedecer o cooldown*/
    }
}

