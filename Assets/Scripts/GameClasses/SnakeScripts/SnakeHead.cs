using UnityEngine;
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
    private int tokenfor=100;
    protected bool paused;
    public GameObject foodPrefab;
    public Camera cam;
    public bool lose=false;
    Vector2 headPos;
    
    public Snake sn;
    public SpawnFood sf;

    bool[,] field;
   
    
    // Use this for initialization
    void Start () {
        int x = (int)(sf.borderLeft.localPosition.x - sf.borderRight.localPosition.x - 1);
        int y = (int)(sf.borderBot.localPosition.y - sf.borderTop.localPosition.y - 1);
        field = new bool [x,y];

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

    public void aibfs()
    {
        bool[,] wasChecked = new bool [x,y];
        Vector2 movedVec = converCoord(headPos);
        wasChecked[(int)movedVec.x, (int)movedVec.y] = false;


         static void BFS(List<int> persons, int times, Boolean[] isInList, List<int> Chain)
        {
            List<int> Persons2 = new List<int>();
            foreach (int per in persons)
            {
                foreach (int person in accounts[per].GetConnections())
                {
                    if (!isInList[person])
                    {
                        Chain.Add(person);
                        Persons2.Add(person);
                        isInList[person] = true;
                    }
                }
            }
            if (times > 1)
            {
                BFS(Persons2, times - 1, isInList, Chain);
            }
        }






    }

    Vector2 converCoord(Vector2 vec)
    {
        return new Vector2(vec.x - sf.borderLeft.position.x, vec.y - sf.borderBot.position.y);
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
            sf.SpawnSnakeFood();
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
        Vector2 movedVec = converCoord(headPos);
        field[(int)movedVec.x, (int)movedVec.y]=true;
        
        
        if (action)
        {
            transform.Translate(dir);

            if (ate)
            {
               
                tailInc();
                ate = false;
                sn.addToken();
               
                
            }
            

            //check if we have tail and move it behind the head
            if (tail.Count > 0)
            {   
                movedVec = converCoord(tail.Last().position);
                field[(int)movedVec.x, (int)movedVec.y] = false;
                tail.Last().position = headPos;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
          

        }
       
       

    }

    



}
