using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnTriggerEnter(Collider collider)
    {
        //Vector3 contactPoint = collider.ClosestPointOnBounds(gameObject.transform.position);
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().DoOnTrigger(gameObject);
            
        Destroy(gameObject);
    }
}
