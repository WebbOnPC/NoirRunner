using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text doshText;
    public static int doshAmount;
    public static int doshTotal;
    public static int doshTotalAmount;

    public Text highScoreText;

    public GameObject Player;
    float beginPos;
    float curPos;
    public int multiplier = 10;

    public float scoreCount;
    public float highScoreCount;
 
    void Start()
    {
        doshTotalAmount = PlayerPrefs.GetInt("doshTotal");
        beginPos = Player.transform.position.x;
    }

    void Update()
    {
        curPos = Player.transform.position.x - beginPos;
        int distance = Mathf.Abs(Mathf.RoundToInt(curPos * multiplier));
        scoreText.text = "Distance: " + distance + "m";

        int doshAmount = Mathf.Abs(Mathf.RoundToInt((distance)));
        int doshTotal  = Mathf.Abs(Mathf.RoundToInt(doshTotalAmount + doshAmount));
        doshText.text = "Dollarydoos: " + "$" + doshTotal;
        PlayerPrefs.SetInt("doshTotal", doshTotal);

        if (distance > PlayerPrefs.GetInt("Best"))
        PlayerPrefs.SetInt("Best", distance);
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("Best") + "m";
    }
}
