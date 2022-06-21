using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolumeInit : MonoBehaviour
{

    [Header("AudioMixer - Drag Here")]
    public AudioMixer masterMixer;

    [Header("Music Volume Slider - Drag Here")]
    public Slider sfxSlider;

    float currentMusicLevel;

    void Start()
    {
        masterMixer.GetFloat("musicVolume", out currentMusicLevel);
        Debug.Log("Current Music Volume : " + currentMusicLevel);

        sfxSlider.GetComponent<Slider>().value = currentMusicLevel;
    }
}