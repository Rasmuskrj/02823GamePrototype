﻿using UnityEngine;
using System.Collections;
using System;

public class Snake : GameClass
{
    public Vector2 dir = Vector2.right;
    public SnakeHead snakeHead;
    public int level = 0;
    // Use this for initialization
    void Start()
    {
        if (gameID % 2 == 0) { cam.transform.localPosition += new Vector3(5, 0, 0); }
        else { cam.transform.localPosition += new Vector3(-5, 0, 0); }
    }

    // Update is called once per frame
    override public void MoveXRaw(float axisx) {
        Debug.Log(axisx);
        if (axisx == 1f && dir != Vector2.left)
        {
            dir = Vector2.right;
            snakeHead.SetDir(dir);
        }
        else if (axisx == -1f && dir != Vector2.right)
        {
            dir = -Vector2.right; // '-right' means 'left'
            snakeHead.SetDir(dir);
        }
        
    }
    override public void MoveYRaw(float axisy) {
        Debug.Log(axisy);
        if (axisy == 1f && dir != -Vector2.up)
        {
            dir = Vector2.up;
            snakeHead.SetDir(dir);
        }
        else if (axisy == -1f && dir != Vector2.up)
        {
            dir = -Vector2.up;    // '-up' means 'down'
            snakeHead.SetDir(dir);
        }
    }

    override public void IncreaseDifficulty()
    {
        difficulty++;
        snakeHead.tailInc();
    }

    override public void ReduceDifficulty()
    {
        if (difficulty == 0)
        {
            Tokens++;
            return;
        }
        difficulty--;
        snakeHead.tailReduce();
    }
    public void addToken()
    {
            Tokens++;
           
        
    }


}
