using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    int health;
    private Breakout gamerefference;
	// Use this for initialization
	void Start () {
        health = 3;
        gamerefference = gameObject.transform.parent.parent.GetComponent<Breakout>();
    }
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        gamerefference.score++;
        if (health == 0)
        {
            Destroy(gameObject);
        }
            
    }
    /*void OnTriggerEnter(Collider collider)
    {
        //Vector3 contactPoint = collider.ClosestPointOnBounds(gameObject.transform.position);
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().DoOnTrigger(gameObject);
            
        Destroy(gameObject);
    }*/
}
