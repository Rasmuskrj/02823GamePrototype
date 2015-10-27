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
        InvokeRepeating("SpawnSnakeFood", 3, 4);
    }

    void SpawnSnakeFood()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBot.position.y);

        Instantiate(foodPrefab,
                new Vector2(x, y),
                Quaternion.identity); // default rotation
        
    }
        // Update is called once per frame
    void Update () {
	
	}
}
