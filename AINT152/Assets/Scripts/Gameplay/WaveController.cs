using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    int currentWave = 0;
    public int enemiesRemaining;

    public LevelSelector levelSelector;
    public RandomSpawner randomSpawner;
    public GameUI uiManager;

    private GameObject playerSpawner;

    private GameObject player;

    private void Start()
    {

    }

    private void Update()
    {
        if(enemiesRemaining == 0 && currentWave!= 0)
        {
            uiManager.waveVictory = true;

            currentWave++;
            enemiesRemaining = currentWave + 4;
        }

        if(currentWave == 0)
        {
            currentWave++;
            enemiesRemaining = currentWave + 4;

            LoadNextLevel();
        }
    }

    public void ReduceEnemies()
    {
        enemiesRemaining--;
    }

    public void LoadNextLevel()
    {
        levelSelector.SetLevel();

        randomSpawner.numberOfEnemyInWave = enemiesRemaining;
        randomSpawner.StartNewWave();

        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawn");
        player = GameObject.Find("Player");
        player.transform.position = playerSpawner.transform.position;
    }
}
