using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIfNotPlaying : MonoBehaviour
{
    private AudioSource currentSound;

    private void Start()
    {
        currentSound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!currentSound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
