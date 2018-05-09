using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioController : MonoBehaviour
{

    // define the audio clips
    public AudioClip clipTakeDamage;
    public AudioClip clipDeath;
    public AudioClip clipShot;
    public AudioClip clipWalking;

    public AudioMixerGroup mixer;

    private AudioSource audioTakeDamage;
    private AudioSource audioDeath;
    private AudioSource audioShot;
    private AudioSource audioWalking;

    public AudioSource AddAudio(AudioClip clip, AudioMixerGroup mixer, bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        newAudio.clip = clip;
        newAudio.outputAudioMixerGroup = mixer;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    public void Awake()
    {
        audioShot = AddAudio(clipShot, mixer, false, false, 0.1f);
        //audioDeath = AddAudio(clipDeath, mixer, false, false, 0.4f);
        //audioWalking = AddAudio(clipWalking, mixer, true, false, 0.4f);
        audioTakeDamage = AddAudio(clipTakeDamage, mixer, false, false, 0.5f);
    }

    public void PlayerDamageSound(float delay)
    {
        audioTakeDamage.PlayDelayed(delay);
    }

    public void PlayerShot(float delay)
    {
        audioShot.pitch = Random.Range(0.75f, 1.5f);
        audioShot.PlayDelayed(delay);
    }
}
