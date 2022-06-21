using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenK : MonoBehaviour
{
    int doshAmount;

    public void addTenK()
    {
        doshAmount += 10000;
        PlayerPrefs.SetInt("doshTotal", doshAmount);
    }
}
