using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    private Transform[] spawners = new Transform[4];
    public GameObject enemy;
    private Vector3 minBounds, maxBounds;

    public float Timer = 2;

    GameObject enemyClone;


    private void Start()
    {
        
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            enemyClone = Instantiate(enemy, new Vector3(Random.Range(-9, 9), Random.Range(-9, 9), 0f), transform.rotation) as GameObject;
            Timer = 2f;
        }
    }
}
