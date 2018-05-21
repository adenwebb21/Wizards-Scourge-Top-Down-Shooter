﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUIManager : MonoBehaviour {

    public AudioSource menuSound;
    public AudioSource hoverSound;

    public Transform helpScreen;
    public Transform creditScreen;

    public void StartGame()
    {
        menuSound.Play();
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleHelpScreen()      // Toggle the help and controls screen
    {
        menuSound.Play();

        if (!helpScreen.gameObject.active)
        {
            helpScreen.gameObject.SetActive(true);
        }
        else
        {
            helpScreen.gameObject.SetActive(false);
        }
    }

    public void ToggleCreditsScreen()       // Toggle credits
    {
        menuSound.Play();

        if (!creditScreen.gameObject.active)
        {
            creditScreen.gameObject.SetActive(true);
        }
        else
        {
            creditScreen.gameObject.SetActive(false);
        }
    }

    public void PlayHoverSound()
    {
        hoverSound.Play();
    }
}
