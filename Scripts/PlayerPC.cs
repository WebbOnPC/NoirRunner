using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPC : MonoBehaviour
{
    //grid size: area player can move
    public static int height = 200;
    public static int width = 200;
    private static Transform[,] grid = new Transform[width, height];

    private bool m_ReadyForInput;
    public Player m_Player;

    // Vector3 tempPos;
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //   tempPos = m_Player.transform.position;

        // flip the sprite
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = true;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            mySpriteRenderer.flipX = false;
        }

        //PC MOVEMENT
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveInput.Normalize();   //didnt seem to do anything
        if (moveInput.sqrMagnitude > 0.5)// Button pressed or held
        {
            if (m_ReadyForInput)
            {
                //prevents object from moving move than once
                m_ReadyForInput = false;//cant move further than 1 unit at a time
                m_Player.Move(moveInput);//move player
            }
        }
        else//not pressed, can move
        {
            m_ReadyForInput = true;//ready to move
        }
    }

    //Will always set one of the coordinates to 0
    public bool Move(Vector2 direction)//Will always set one of the coordinates to 0
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();//makes either x or y = 1
        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else if (ValidMove())
        {
            transform.Translate(direction);
            return true;
        }
        else
        {
            return false;
        }
    }

    bool ValidMove()//CHECK VALID MOVE
    {
        foreach (Transform children in transform)//IF
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);//THESE
            int roundedY = Mathf.RoundToInt(children.transform.position.y);//THESE
            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)//MEET THESE CONDITIONS
            {
                return false; //NEXT MOVE WOULD BE OUTSIDE OF THESE CONDITIONS
                              // FAILED CANT MOVE
            }
            if (grid[roundedX, roundedY] != null)//or outside of grid
                return false;  // cant move
        }
        return true;// IS VALID CAN MOVE
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}