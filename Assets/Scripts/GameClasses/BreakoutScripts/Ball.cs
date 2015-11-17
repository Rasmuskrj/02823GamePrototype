using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float initialspeed = 1.0f;
    public Rigidbody2D rb;
    private float mag;
    private float minAngVel = 3f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        float xDir = Random.Range(-1.0f, 1.0f);
        Vector2 Vec = new Vector2(xDir, 1);
        rb.velocity=(Vec * initialspeed);
        mag = rb.velocity.magnitude;
        //Debug.Log(rb.velocity);
        //TriggerScript.setBall(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y < -11)
        {
            gameObject.GetComponentInParent<BallSpawner>().LaunchBall();
            Destroy(gameObject);
        }
	}
    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) <= minAngVel)
        {
            float sign = 1;
            if (Mathf.Sign(rb.velocity.y) == -1) { sign = -1; }
            rb.velocity = new Vector2(rb.velocity.x, 5*sign);
        }
        if (Mathf.Abs(rb.velocity.x) <= minAngVel)
        {
            float sign = 1;
            if (Mathf.Sign(rb.velocity.x) == -1) { sign = -1; }
            rb.velocity = new Vector2(minAngVel*sign, rb.velocity.y);
        }
        rb.velocity = rb.velocity.normalized * mag;
    }
    public void InceaseMag()
    {
        mag++;
    }
    /*public void DoOnTrigger (GameObject other)
    {
        //Debug.Log("WHAT IS WRONG WITH YOU");

        Collider collider = gameObject.GetComponent<Collider>();
        Vector3 contactPoint = collider.ClosestPointOnBounds(other.transform.position);
        Debug.Log(contactPoint);
        Vector3 normal = Vector3.Normalize(gameObject.transform.position - contactPoint);
        rb.velocity = rb.velocity - 2 * Vector2.Dot(rb.velocity, normal) * normal;
        rb.velocity = rb.velocity.normalized * mag;
    }*/

}
