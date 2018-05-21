using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownText : MonoBehaviour {

    public float timer = 5f;
    private float shotgunCoolDown = 5f;

    public coolDownManager text;

    private void OnEnable()
    {
        timer = 5f;
        gameObject.GetComponent<Text>().text = "5";
    }

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            text.ResetCoolDown();
        }

        gameObject.GetComponent<Text>().text = timer.ToString("#.#");       // Display the cooldown to one decimal point
    }


}
