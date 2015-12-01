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
        //InvokeRepeating("SpawnSnakeFood", 3, 0.2f);
        SpawnSnakeFood();
    }

   public void SpawnSnakeFood()
    {
        int x = (int)Random.Range(borderLeft.localPosition.x, borderRight.localPosition.x);
        int y = (int)Random.Range(borderBot.localPosition.y+1, borderTop.localPosition.y);
     
        GameObject newfood = Instantiate(foodPrefab);
        newfood.transform.parent = transform;
        newfood.transform.localPosition = new Vector3(x, y);
    }
        // Update is called once per frame
    
}
