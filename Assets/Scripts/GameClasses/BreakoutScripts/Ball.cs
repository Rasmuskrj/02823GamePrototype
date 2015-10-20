﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float initialspeed = 1.0f;
    public Rigidbody rb;
    private float mag;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        float xDir = Random.Range(-1.0f, 1.0f);
        Vector3 Vec = new Vector3(xDir, 1, 0);
        rb.velocity=(Vec * initialspeed);
        mag = rb.velocity.magnitude;
        Debug.Log(rb.velocity);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DoOnTrigger (Collider collider)
    {
        Vector3 contactPoint = collider.ClosestPointOnBounds(gameObject.transform.position);
        Vector3 normal = Vector3.Normalize(gameObject.transform.position - contactPoint);
        rb.velocity = rb.velocity - 2 * Vector2.Dot(rb.velocity, normal) * normal;
        rb.velocity = rb.velocity.normalized * mag;
    }
    void OnTriggerEnter (Collider collider)
    {
        DoOnTrigger(collider);

    }
}
