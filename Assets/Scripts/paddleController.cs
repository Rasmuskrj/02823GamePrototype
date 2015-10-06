using UnityEngine;
using System.Collections;

public class paddleController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -12.5f, 12.5f),-10.0f,0.0f);
	}

	void OnCollisionEnter(Collision collision){
	
		float velo = collision.rigidbody.velocity.magnitude;
		collision.rigidbody.velocity = new Vector3 ((collision.transform.position.x - transform.position.x) * 8,collision.rigidbody.velocity.y,0f);

		if (collision.rigidbody.velocity.magnitude < velo) {
			collision.rigidbody.velocity *= velo / collision.rigidbody.velocity.magnitude;
		}
	}
}


