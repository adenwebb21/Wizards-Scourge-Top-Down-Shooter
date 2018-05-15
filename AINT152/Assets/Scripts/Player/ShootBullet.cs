using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Animator playerAnim;
    public Transform bulletSpawn;

    private Transform[] fanShotSpawners;

    public float fireTime = 0.5f;
    public float initialDelay = 0.07f;
    private bool isFiring = false;

    private float fanShotCoolDown = 5f;

    private PlayerAudioController shotAudio;

    private float timer;

    private void Start()
    {
        shotAudio = gameObject.GetComponent<PlayerAudioController>();

        fanShotSpawners = gameObject.transform.GetChild(2).GetComponentsInChildren<Transform>();
    }

    void SetFiring()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Invoke("Fire", fireTime);
        }
        else if (!Input.GetKey(KeyCode.Mouse0))
        {
            isFiring = false;
            playerAnim.SetTrigger("attack_end");        // The attack only ends when the player releases the fire button
        }
    }

    void CreateBolt()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void CreateFanBolts()
    {
        for(int i = 1; i < fanShotSpawners.Length; i++)
        {
            Instantiate(bulletPrefab, fanShotSpawners[i].position, fanShotSpawners[i].rotation);
        }      
    }

    void Fire()
    {  
        isFiring = true;

        Invoke("CreateBolt", initialDelay);

        shotAudio.PlayerShot(initialDelay);

        Invoke("SetFiring", fireTime);       
    }

    void FireFanShot()
    {
        CreateFanBolts();
    }

    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                playerAnim.SetTrigger("attack_start");
                Fire();
            }
        }

        if(Input.GetMouseButtonDown(1) && timer <= 0)
        {
            timer = fanShotCoolDown;

            FireFanShot();
        }
    }
}

