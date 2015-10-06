using UnityEngine;
using System.Collections;

public class paddleAI : MonoBehaviour {
	private Transform ball;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GameObject.FindWithTag("Ball")){

			ball = GameObject.FindWithTag("Ball").transform;

			if (ball.position.y > 0){ 
				transform.position = new Vector3 (Mathf.Lerp( transform.position.x, ball.position.x, speed * Time.deltaTime),transform.position.y,0f);
				transform.position = new Vector3 (Mathf.Clamp( transform.position.x, -7.5f, 7.5f),transform.position.y, 0f);
			}
		}
	}
	void OnCollisionEnter(Collision collision){
		
		float velo = collision.rigidbody.velocity.magnitude;
		collision.rigidbody.velocity = new Vector3 ((collision.transform.position.x - transform.position.x) * 8,collision.rigidbody.velocity.y,0f);
		
		if (collision.rigidbody.velocity.magnitude < velo) {
			collision.rigidbody.velocity *= velo / collision.rigidbody.velocity.magnitude;
		}
	}
	
}
