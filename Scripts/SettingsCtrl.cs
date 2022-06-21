using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    // Blood SettingsCtrl
public class SettingsCtrl : MonoBehaviour
{
    public GameObject blood;
    public Toggle BloodToggle;

    void Start()
    {
        CheckBlood();
        bool BloodBool = (PlayerPrefs.GetInt("BloodOn") == 1) ? true : false;
        BloodToggle.isOn = BloodBool;
    }

    public void CheckBlood()
    {
        if (PlayerPrefs.HasKey("BloodOn"))
        {
            if (PlayerPrefs.GetInt("BloodOn") > 0)
            {
                blood.SetActive(true);
            }
            else
            {
                blood.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BloodOn", 1);
            blood.SetActive(true);
        }
    }

    public void BloodBool(bool value)
    { 
        if (value == true)
        {
            PlayerPrefs.SetInt("BloodOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("BloodOn", 0);
        }
        CheckBlood();
    }
}