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

    public bool isAI;

    public Snake sn;
    public SpawnFood sf;

    //bool[,] field;

    private int x;
    private int y;

    // Use this for initialization
    void Start () {
        x = (int)(sf.borderRight.localPosition.x - sf.borderLeft.localPosition.x - 1);
        y = (int)(sf.borderTop.localPosition.y - sf.borderBot.localPosition.y - 1);
        //field = new bool [x,y];

        tailInc();
        tailInc();
        float speed = 0.1f;
        if (isAI) { speed = 1f/30f;
        dir = Vector2.down;
        }
        if (action)
        {
            InvokeRepeating("move", 0.5f, speed);
        }
        else
        {
            sn.playerLost();
            //You lose screen appears
        }
        


    }
	
	// Update is called once per frame
	void Update () {
        SetDir(dir);
     

    }

    public void aibfs()
    {
        //bool[,] wasChecked = new bool [x,y];
        Vector2 movedVec = converCoord(headPos);
        //wasChecked[(int)movedVec.x, (int)movedVec.y] = false;


         /*static void BFS(List<int> persons, int times, Boolean[] isInList, List<int> Chain)
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
        }*/






    }

    public void AIDirection(Vector2 pos)
    {
        if (pos.y == 1) {
            if (pos.x == 1) { dir = Vector2.up; }
            else if (pos.x == x) { dir = Vector2.left; }
        }
        else if (pos.y == 2)
        {
            if (pos.x == 1) { }
            else if (pos.x == x) { }
            else if (pos.x%2 == 1) { dir = Vector2.up; }
            else { dir = Vector2.right; }
        }
        else if (pos.y == y)
        {
            if (pos.x % 2 == 1) { dir = Vector2.right; }
            else { dir = Vector2.down; }
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
            //play ate sound
            SoundManager.Instance.appleBoing.Play();

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
        if (isAI)
        {
            Vector2 movedVec = converCoord(headPos);
            AIDirection(movedVec);
        }
        
        
        
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
                //movedVec = converCoord(tail.Last().position);
                //field[(int)movedVec.x, (int)movedVec.y] = false;
                tail.Last().position = headPos;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);

            }
          

        }
       
       

    }

    



}
