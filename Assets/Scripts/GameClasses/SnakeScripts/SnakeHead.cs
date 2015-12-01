﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class SnakeHead : MonoBehaviour {
    //start movement - to the right
    Vector2 dir = Vector2.right;
    bool action = true;
    // Keep Track of Tail
    public List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;
    protected bool paused;
    public GameObject foodPrefab;
    public Camera cam;
    public bool lose=false;
    Vector2 headPos;
    public int apples=0;
    public Snake sn;
    
    


    // Use this for initialization
    void Start () {
        tailInc();
        tailInc();
        if (action)
        {
            InvokeRepeating("move", 0.5f, 0.1f);
        }
        else
        {
            //You lose screen appears
        }

        


    }
	
	// Update is called once per frame
	void Update () {
        SetDir(dir);
     

    }


    
    
    public void SetDir(Vector2 newDir)
    {
        dir = newDir;
        
    }

    void OnPauseGame()
    {
        Time.timeScale = 0;
    }

    void OnResumeGame()
    {
       
    }

    void FixedUpdate()
    {
        //controling();
        
   
        
    }
    
    void OnTriggerEnter2D(Collider2D coll){
       
        if (coll.name.StartsWith("foodPrefab"))
        {
            // Get longer in next Move call
            ate = true;
      
            // Remove the Food
            Destroy(coll.gameObject);
        }
        
        // Collided with Tail or Border
        else
        {
           if (coll.name.StartsWith("tailPrefab") || coll.gameObject.CompareTag("Walls"))
            {
                action = false;
                Debug.Log("Collision", coll.gameObject);
            }
            
        }
    }

   

    //Increases tail by 1 block
    public void tailInc()
    {
        // Load Prefab into the world
        GameObject g = (GameObject)Instantiate(tailPrefab, headPos, Quaternion.identity);

        // Keep track of it in our tail list
        tail.Insert(0, g.transform);

       
    }

    public void tailReduce()
    {
        if(tail.Count > 0)
        {
            tail.RemoveAt(tail.Count - 1);
        }
       
        
    }
   
     
    public void move() {

        headPos = transform.position;
        
        
        if (action)
        {
            transform.Translate(dir);

            if (ate)
            {
               
                tailInc();
                ate = false;
                apples++;
                if (apples == 1)
                {
                    apples = 0;
                    sn.addToken();
                }
                
            }
            

            //check if we have tail and move it behind the head
            if (tail.Count > 0)
            {
                tail.Last().position = headPos;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
          

        }
       
       

    }

    



}
