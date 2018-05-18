using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolDownManager : MonoBehaviour
{
    public Sprite greyedOut;
    public Sprite coloured;

    public Image imageComp;

    public Text countDownText;

    private void Start()
    {
        ResetCoolDown();
    }

    public void StartCoolDown()
    {
        imageComp.sprite = greyedOut;
        countDownText.gameObject.SetActive(true);
    }

    public void ResetCoolDown()
    {
        imageComp.sprite = coloured;
        countDownText.gameObject.SetActive(false);
    }


}
