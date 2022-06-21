using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioClip ButtonAudioClip;
    AudioSource buttonAudio;

    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
    }

    public void ButtonPress()
    {
        buttonAudio.PlayOneShot(ButtonAudioClip, 1F);
    }
}
