using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    int health;
	// Use this for initialization
	void Start () {
        health = 3;
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
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
