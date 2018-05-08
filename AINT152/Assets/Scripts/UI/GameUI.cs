using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameUI : MonoBehaviour
{
    private int health;
    private int score;

    public Transform pauseMenu;
    public Transform optionsMenu;
    public Transform deathScreen;
    public Transform waveScreen;
    public Transform inGameStats;

    public AudioMixer mixer;


    public ManageUpgradeScreen upgradeScreenScript;

    public Text healthText;
    public Text scoreText;
    public Text waveText;

    public Text pressSpaceText;

    public WaveController controller;
    public UpgradeController upgradeController;

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

    public void UpdateUI()
    {
        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Score: " + score.ToString();
        waveText.text = "Wave: " + controller.currentWave.ToString();
    }

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
            pressSpaceText.text = "Press space to begin next wave";
            waveScreen.gameObject.SetActive(true);

            if((controller.currentWave - 1) % 5 == 0)
            {
                upgradeScreenScript.EnableUpgradeScreen();
                pressSpaceText.text = "Press space to confirm your choice";
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
            upgradeController.ActivateSelection();

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

    public void OptionsMenu()
    {
        if (!optionsMenu.gameObject.active)
        {
            optionsMenu.gameObject.SetActive(true);
        }
        else
        {
            optionsMenu.gameObject.SetActive(false);
        }
    }

    public void SetMasterVolume(float newValue)
    {
        mixer.SetFloat("masterVolume", newValue);
    }

    public void SetMusicVolume(float newValue)
    {
        mixer.SetFloat("musicVolume", newValue);
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

