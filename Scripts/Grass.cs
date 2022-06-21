using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    //public BoxCollider2D Sensor;

    Animator anim;

   
    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>(); 
    }

    void OnTriggerEnter2D(Collider2D col)
     {
         if (col.CompareTag("Player"))
         {
             anim.SetInteger("State", 1);
         }
     }

     void OnTriggerExit2D(Collider2D col)
     {
         if (col.CompareTag("Player"))
         {
             anim.SetInteger("State", 0);
         }
     }/*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Sensor)
        {
            anim.SetInteger("State", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Sensor)
        {
            anim.SetInteger("State", 0);
        }
    }*/
}
