using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTest : MonoBehaviour {

    private AudioSource audio;

    // The script is purely for the sound effects slider sound volume

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();      
    }

    public void PlaySound()
    {
        audio.Play();
    }
}
