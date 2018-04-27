using UnityEngine;
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
    public Transform deathScreen;
    public Transform waveScreen;
    public Transform inGameStats;

    public ManageUpgradeScreen upgradeScreenScript;

    public Text healthText;
    public Text scoreText;
    public Text waveText;

    public WaveController controller;

    public bool playerDead = false;
    public bool waveVictory = false;

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
        waveText.text = "Wave: 1";
        Time.timeScale = 1;
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
        waveText.text = "Wave: " + controller.currentWave.ToString();
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

        if(playerDead)
        {
            Time.timeScale = 0.2f;
            deathScreen.gameObject.SetActive(true);
            deathScreen.gameObject.GetComponentsInChildren<Text>()[1].text = "Score: " + score.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerDead)
        {
            playerDead = false;
            Time.timeScale = 1f;
            deathScreen.gameObject.SetActive(false);
            SceneManager.LoadScene("Game");
        }

        if(waveVictory)
        {
            waveScreen.gameObject.SetActive(true);

            if((controller.currentWave - 1) % 5 == 0)
            {
                upgradeScreenScript.EnableUpgradeScreen();
            }
            else
            {
                upgradeScreenScript.DisableUpgradeScreen();
            }

            Time.timeScale = 0.2f;
        }

        if(waveVictory && Input.GetKeyDown(KeyCode.Space))
        {
            UpdateUI();

            Time.timeScale = 1f;
            waveVictory = false;
            waveScreen.gameObject.SetActive(false);

            controller.LoadNextLevel();
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

