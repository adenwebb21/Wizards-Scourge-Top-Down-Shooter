using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour {

    float timer = 5;
    float decreaseValue = 0.2f;

    float maximumValue = 6;
    float currentValue = 0;
    float increaseValue = 0.4f;

    public Canvas qte;

    private void Update()
    {
        if(qte.gameObject.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                currentValue += increaseValue;
            }

            timer -= Time.deltaTime;

            if()
        }
    }
}
