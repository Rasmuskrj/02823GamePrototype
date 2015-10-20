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
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().DoOnTrigger(gameObject.GetComponent<Collider>());
            
        Destroy(gameObject);
    }
}
