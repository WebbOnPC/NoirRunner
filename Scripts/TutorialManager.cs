using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorial;

    public void Start()
    {
        if (PlayerPrefs.GetInt("TutorialPlayed") > 0)
        {
            tutorial.SetActive(false);
        }
        else
        {
            tutorial.SetActive(true);
        }
    }
    public void TutorialPlayed()
    {
        PlayerPrefs.SetInt("TutorialPlayed", 1);
    }

}
