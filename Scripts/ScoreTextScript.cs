using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public int gemCount;
    private GameObject[] gems;

    Text gemtext;



    void Start()
    {
        gemtext = GetComponent<Text>();
    }

    void Update()
    {
        gems = GameObject.FindGameObjectsWithTag("Gem");
        gemCount = gems.Length;

        gemtext.text = gemCount.ToString();
    }

    public void ResetGemCount()
    {
    // gemAmount = 0;
    }
}
