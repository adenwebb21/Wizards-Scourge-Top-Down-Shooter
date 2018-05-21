using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolDownManager : MonoBehaviour
{
    public Sprite greyedOut;
    public Sprite coloured;

    public Sprite spentCharge;
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
        imageComp.sprite = greyedOut;
        countDownText.gameObject.SetActive(true);
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
        switch(currentNumberOfCharges)
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
