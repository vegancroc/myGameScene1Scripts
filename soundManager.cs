using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource audioS;

    [Header("Effects")]
    public AudioClip lightning;
    public AudioClip rain;
    public AudioClip whisper;
    public AudioClip voice1;
    public AudioClip walkSound;

    public void playThunderEffect()
    {
        audioS.clip = lightning;
        audioS.Play();
    }

    public void playRain()
    {
        audioS.clip = rain;
        audioS.Play();
    }

    public void playWhisper(float volume)
    {
        audioS.PlayOneShot(whisper, volume);
    }

    public void playVoice1(float volume)
    {
        audioS.PlayOneShot(voice1, volume);
    }

    public void playWalkSound(float volume)
    {
        audioS.PlayOneShot(walkSound, volume);
    }
}
