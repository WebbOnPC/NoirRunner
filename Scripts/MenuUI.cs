using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI: MonoBehaviour
{
    public Text doshText;
    public Text highScoreText;
    public Text coinCounter;
    public string key = "Death Count: ";

    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Best") + "m";
    }
    public void Update()
    {
        if (coinCounter != null)
        {
            coinCounter.text = key + PlayerPrefs.GetInt(key);
        }

        doshText.text = "Dollarydoos: " + "$" + PlayerPrefs.GetInt("doshTotal");
    }
}
