using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {
    public Transform ballprefab;
    public float initialspeed = 1.0f;
    public Transform player2;
    public Breakout breakout;
    // Use this for initialization
    void Start()
    {
        LaunchBall();
    }
    public void LaunchBall()
    {
        if (breakout.lives < 1) { return; }
        else { breakout.lives--; }
        Vector3 offset;
        Transform newball;
        
        offset = new Vector3(0f, 1f, 0f);
        newball = Instantiate(ballprefab);
        newball.localPosition = player2.position + offset;
        newball.rotation = Quaternion.identity;
        newball.parent = transform;

        Vector2 offset2D = new Vector2(offset.x, offset.y);
        new WaitForSeconds(2);
        newball.GetComponent<Rigidbody2D>().AddForce(offset2D * initialspeed);
        breakout.ball = newball.gameObject.GetComponent<Ball>();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
