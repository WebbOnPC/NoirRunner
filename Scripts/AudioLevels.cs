using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioLevels : MonoBehaviour
{ 
    public Slider MusicSlider;
    public Slider SfxSlider;
    public AudioMixer masterMixer;



    void Awake()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVol");
        SfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
    }

    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVol");
        SfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
    }

    public void SetMusicLvl(float musicLvl)
    {
        musicLvl = MusicSlider.value;
        masterMixer.SetFloat("musicVol", Mathf.Log10(musicLvl) * 20);
        PlayerPrefs.SetFloat("musicVol", musicLvl);
        PlayerPrefs.Save();
    }

    public void SetSfxLvl(float sfxLvl)
    {
        sfxLvl = SfxSlider.value;
        masterMixer.SetFloat("sfxVol", Mathf.Log10(sfxLvl) * 20);
        PlayerPrefs.SetFloat("sfxVol", sfxLvl);
        PlayerPrefs.Save();
    }
}