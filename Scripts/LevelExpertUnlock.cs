using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExpertUnlock : MonoBehaviour
{
    public int gemCount;
    private GameObject[] gems;


    void Update()
    {
        gems = GameObject.FindGameObjectsWithTag("Gem");
        gemCount = gems.Length;


        if (gemCount == 0)
        {
            PlayerPrefs.SetInt("expertUnlocked", 1);
        }

    }
}
