using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float initialspeed = 1.0f;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody> ();
		float xDir = Random.Range (-1.0f, 1.0f);
		Vector3 Vec = new Vector3 (xDir, -1, 0); 
		rb.AddForce (Vec * initialspeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10) {
            Score.livesLost += 1;
            GameObject.Find("BallSpawner").SendMessage("LaunchBall", 2);
            Destroy(gameObject);
        }
	}
}
