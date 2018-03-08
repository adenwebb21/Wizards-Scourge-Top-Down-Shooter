﻿using UnityEngine;
using System.Collections;
public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Animator playerAnim;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;

    void SetFiring()
    {
        isFiring = false;
    }

    void Fire()
    {
        playerAnim.SetTrigger("attack");
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
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
                
                Fire();
            }
        }
    }
}

