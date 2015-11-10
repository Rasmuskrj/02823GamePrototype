using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    private static Ball ball;
	// Use this for initialization
	void Start () {
	
	}
	public static void setBall (Ball newball)
    {
        ball = newball;
    }
	// Update is called once per frame
	void Update () {
	
	}
    /*void OnTriggerEnter(Collider collider)
    {
        ball.DoOnTrigger(gameObject);
    }*/
}
