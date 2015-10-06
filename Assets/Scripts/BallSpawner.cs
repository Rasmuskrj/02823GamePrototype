using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {
	public Transform ballprefab;
	public float initialspeed = 1.0f;
	public Transform player2;

	// Use this for initialization
	void Start () {
		LaunchBall (1);
	}
	void LaunchBall (int player) {
        Vector3 offset;
		Transform newball;
		
        offset = new Vector3(0f, 1f, 0f);
        newball = Instantiate (ballprefab);
        newball.position = player2.position + offset;
        newball.rotation = Quaternion.identity;
        newball.parent = player2;
		
        new WaitForSeconds(2);
        newball.parent = null;
        newball.GetComponent<Rigidbody>().AddForce(offset * initialspeed);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
