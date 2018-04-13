﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private int health;
    private int score;
    private string gameInfo = "";
    //private Rect boxRect = new Rect(10, 10, 300, 50);

    public Transform pauseMenu;
    public Transform inGameStats;
    public Text healthText;
    public Text scoreText;

    void OnEnable()
    {
        PlayerHealth.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }

    void OnDisable()
    {
        PlayerHealth.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }

    void Start()
    {
        UpdateUI();
    }

    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    //void OnGUI()
    //{
    //    GUI.Box(boxRect, gameInfo);
    //}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!pauseMenu.gameObject.active)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToTitleScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

