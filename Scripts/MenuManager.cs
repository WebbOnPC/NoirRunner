using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button mediumButton;
    public Button hardButton;
    public Button expertButton;

    void Start()
    {
        if (PlayerPrefs.GetInt("mediumUnlocked") > 0)
        {
            mediumButton.interactable = true;
        }
        else
        {
            PlayerPrefs.SetInt("mediumUnlocked", 0);
            mediumButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("hardUnlocked") > 0)
        {
            hardButton.interactable = true;
        }
        else
        {
            PlayerPrefs.SetInt("hardUnlocked", 0);
            hardButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("expertUnlocked") > 0)
        {
            expertButton.interactable = true;
        }
        else
        {
            PlayerPrefs.SetInt("expertUnlocked", 0);
            expertButton.interactable = false;
        }
    }
}
