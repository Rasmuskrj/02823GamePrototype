using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeHead : MonoBehaviour {
    //start movement - to the right
    Vector2 dir = Vector2.right;
    bool action = true;
    // Keep Track of Tail
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;
    protected bool paused;
    public GameObject foodPrefab;
    





    // Use this for initialization
    void Start () {
       
        InvokeRepeating("move", 0.5f, 0.2f);
         


    }
	
	// Update is called once per frame
	void Update () {

    }
   
   
    




   //private Vector2 controling()
   // {
        
  
   //        if (Input.GetKey(KeyCode.RightArrow) && dir!=Vector2.left)
   //             dir = Vector2.right;
   //        else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
   //          dir = -Vector2.right; // '-right' means 'left'
   //         else if (Input.GetKey(KeyCode.UpArrow) && dir != -Vector2.up)
   //             dir = Vector2.up;
   //         else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
   //             dir = -Vector2.up;    // '-up' means 'down'
      
   //     return dir;
   // }

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

     void move() {
        Vector2 v = transform.position;
       
        if (action)
        {
           transform.Translate(dir);

            if (ate)
            {
                
                // Load Prefab into the world
                GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

                // Keep track of it in our tail list
                tail.Insert(0, g.transform);
                ate = false;
            }

            if (tail.Count > 0)
            {
                tail.Last().position = v;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }

        }
        else
            OnPauseGame();
           
       

    }

    



}
