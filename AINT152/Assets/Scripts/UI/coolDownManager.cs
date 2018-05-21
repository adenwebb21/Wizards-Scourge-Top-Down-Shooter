using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolDownManager : MonoBehaviour
{
    public Sprite greyedOut;        // Different options for the cooldown sprite itself
    public Sprite coloured;

    public Sprite spentCharge;      // And for the charges in the event that this upgrade is gained
    public Sprite usableCharge;

    public Image imageComp;

    public Image chargeOne;
    public Image chargeTwo;

    public Text countDownText;

    public int maxNumberOfCharges = 1;
    public int currentNumberOfCharges;

    private void Start()
    {
        ResetCoolDown();
        currentNumberOfCharges = maxNumberOfCharges;
        UpdateCharges();
    }

    public void StartCoolDown()
    {
        imageComp.sprite = greyedOut;       // Icon is greyed while ability inacessable 
        countDownText.gameObject.SetActive(true);       // And the text countdown starts
    }

    public void ResetCoolDown()
    {
        if(currentNumberOfCharges < maxNumberOfCharges)     
        {
            currentNumberOfCharges = maxNumberOfCharges;
            UpdateCharges();
        }

        imageComp.sprite = coloured;
        countDownText.gameObject.SetActive(false);
    }

    public void UpdateCharges()
    {
        switch(currentNumberOfCharges)      // Based on the current number of charges, a specific combination of charges is presented
        {
            case 0:
                chargeOne.sprite = spentCharge;
                chargeTwo.sprite = spentCharge;
                break;
            case 1:
                chargeOne.sprite = usableCharge;
                chargeTwo.sprite = spentCharge;
                break;
            case 2:
                chargeOne.sprite = usableCharge;
                chargeTwo.sprite = usableCharge;
                break;
            default:
                break;
        }
    }


}
