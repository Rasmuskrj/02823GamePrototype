using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
    public GameObject foodPrefab;

   
    public Transform borderTop;
    public Transform borderBot;
    public Transform borderLeft;
    public Transform borderRight;
    // Use this for initialization
    void Start () {
        // Spawn food every 4 seconds, starting in 3
         InvokeRepeating("SpawnSnakeFood", 3, 0.2f);
        SpawnSnakeFood();
    }

    void SpawnSnakeFood()
    {
        int x = (int)Random.Range(borderLeft.position.x+1, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y-1, borderBot.position.y);
     
        Instantiate(foodPrefab,
                new Vector2(x, y),
                Quaternion.identity); // default rotation
        
    }
        // Update is called once per frame
    void Update () {
        if (GameObject.Find("foodPrefab(Clone)") == null)
           
        {
           
            SpawnSnakeFood();
        }
	
	}
}
