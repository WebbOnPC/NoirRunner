using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] Transform castPoint;
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    Rigidbody2D rb2d;

    public GameObject box;
    Vector3 tempPos;

    AudioSource rockAudio;

    void Start()
    {
        //tempPos = box.transform.position;
        rb2d = GetComponent<Rigidbody2D>();

        rockAudio = GetComponent<AudioSource>();
    }

    public void Update()
    { 
        //box position
        tempPos = box.transform.position;

        //if can see object stop, else move down
        if (CanSeePlayer(agroRange) )
        {
            StopMoving();
        }
        else
        {
            MoveDown();
        }        
    }

    void MoveDown()
    {
        tempPos.y -= 1;
        box.transform.position = tempPos;

       if (CanSeePlayer(agroRange))
       {
           rockAudio.PlayOneShot(rockAudio.clip, 0.6F);
       }
    }

    //ray cast
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.down * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player") ||  hit.collider.gameObject.CompareTag("Wall") || hit.collider.gameObject.CompareTag("Gem") || hit.collider.gameObject.CompareTag("Dirt") || hit.collider.gameObject.CompareTag("Box"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }
        return val;
    }

    void StopMoving()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}