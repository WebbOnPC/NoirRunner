using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameObject : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Splat>().enabled = true;
    }
}
