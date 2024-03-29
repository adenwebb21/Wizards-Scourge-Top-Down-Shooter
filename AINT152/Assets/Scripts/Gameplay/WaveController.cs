﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour {

    public int currentWave = 1;
    public int enemiesRemaining;

    public UnityEvent ResetCoolDowns;

    public LevelSelector levelSelector;
    public RandomSpawner randomSpawner;
    public GameUI uiManager;

    public GameObject waveVictorySound;

    private GameObject playerSpawner;

    private GameObject player;

    private void Update()
    {
        if(enemiesRemaining == 0 && currentWave!= 0)
        {
            uiManager.waveVictory = true;
            Instantiate(waveVictorySound);

            currentWave++;
            enemiesRemaining = currentWave + Random.Range(1, 5);
        }

        if(currentWave == 0)
        {
            currentWave++;
            enemiesRemaining = currentWave + Random.Range(1, 5);

            LoadNextLevel();
        }
    }

    public void ReduceEnemies()
    {
        enemiesRemaining--;
    }

    public void LoadNextLevel()
    {
        GameObject[] allShots = GameObject.FindGameObjectsWithTag("Bolt");
        GameObject[] allPickups = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject obj in allShots)        // Clear out shots and health drops from the level
        {
            Destroy(obj);
        }

        foreach (GameObject obj in allPickups)
        {
            Destroy(obj);
        }

        ResetCoolDowns.Invoke();

        levelSelector.SetLevel();

        randomSpawner.numberOfEnemyInWave = enemiesRemaining;
        randomSpawner.StartNewWave();

        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawn");
        player = GameObject.Find("Player");
        player.transform.position = playerSpawner.transform.position;
    }
}
