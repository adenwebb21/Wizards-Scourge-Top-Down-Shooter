using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    public PlayerHealth playerHealth;
    public coolDownManager charges;
    public GameUI UI;

    private int buttonSelected = 0;

    public void RefillHealth()      // Will be executed from a button click
    {
        UI.menuSound.Play();
        buttonSelected = 1;
    }

    public void IncreaseMaxHealth()     
    {
        UI.menuSound.Play();
        buttonSelected = 2;
    }

    public void IncreaseShotgunCharges()
    {
        UI.menuSound.Play();
        buttonSelected = 3;
    }

    public void ActivateRegenerativeHealth()
    {
        UI.menuSound.Play();
        buttonSelected = 4;
    }

    public void ActivateSelection()     // Called when the player presses space to confirm selection
    {
        switch(buttonSelected)
        {
            case 1:
                playerHealth.RefillHealth();
                break;
            case 2:
                playerHealth.IncreaseMaxHealth();
                break;
            case 3:
                charges.maxNumberOfCharges++;
                charges.chargeOne.gameObject.SetActive(true);
                charges.chargeTwo.gameObject.SetActive(true);
                break;
            case 4:
                playerHealth.isRegenerating = true;
                break;
            default:
                break;
        }

        buttonSelected = 0;
    }


	
}
