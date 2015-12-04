using UnityEngine;
using System.Collections;
using System;

public class Snake : GameClass
{
    public Vector2 dir = Vector2.right;
    public Vector2 olddir=Vector2.left;
    public SnakeHead snakeHead;
    private int scorefortoken = 100;
    private int progressOnToken = 0;
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
            olddir = dir;
            dir = Vector2.right;

            if (olddir != Vector2.right)
            {
                snakeHead.SetDir(dir);
                olddir = Vector2.zero;

            }
            
        }
        else if (axisx == -1f && dir != Vector2.right)
        {
            olddir = dir;
            dir = -Vector2.right; // '-right' means 'left'


            if (olddir != Vector2.left)
            {
                snakeHead.SetDir(dir);
                olddir = Vector2.zero;

            }
            
            
        }
        
    }
    override public void MoveYRaw(float axisy) {
        Debug.Log(axisy);
        if (axisy == 1f && dir != -Vector2.up)
        {
            olddir = dir;
            dir = Vector2.up;
            if(olddir != Vector2.up){
                snakeHead.SetDir(dir);
                olddir = Vector2.zero;

            }
                
            
        }
        else if (axisy == -1f && dir != Vector2.up)
        {
            olddir = dir;
            dir = -Vector2.up;    // '-up' means 'down'

            if (olddir != -Vector2.up)
            {
                snakeHead.SetDir(dir);
                olddir = Vector2.zero;

            }
            
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
        progressOnToken += 20;
        if (progressOnToken>=100)
        {
            Tokens++;
            progressOnToken -= 100;
        }
            
           
        
    }


}
