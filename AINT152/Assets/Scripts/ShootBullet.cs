﻿using UnityEngine;
using System.Collections;
public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Animator playerAnim;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public float initialDelay = 0.07f;
    private bool isFiring = false;

    void SetFiring()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Invoke("Fire", fireTime);
        }
        else if(!Input.GetKey(KeyCode.Mouse0))
        {
            isFiring = false;
            playerAnim.SetTrigger("attack_end");
        }
        
    }

    void CreateBolt()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void Fire()
    {  
        isFiring = true;

        Invoke("CreateBolt", initialDelay);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetFiring", fireTime);    

        
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                playerAnim.SetTrigger("attack_start");
                Fire();
            }
        }
    }
}
