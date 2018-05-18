﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetainVolumeAccrossSceneChange : MonoBehaviour
{
    public Slider master;
    public Slider music;
    public Slider sound;

    private void Start()
    {
        master.value = PlayerPrefs.GetFloat("masterVolume");
        music.value = PlayerPrefs.GetFloat("musicVolume");
        sound.value = PlayerPrefs.GetFloat("soundVolume");
    }

}