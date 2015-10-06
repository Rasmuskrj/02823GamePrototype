using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    private Vector3 defaultPos;
    private float downMovement = 0f;
	// Use this for initialization
	void Start () {
        defaultPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameObject.transform.position = defaultPos - new Vector3 (0, numberOfBricks * 0.1f+downMovement,0);
        downMovement += 0.003f;
        if (gameObject.transform.position.y < -9.5f)
        {
            GameOverManager.Player1Win();
        }
	}
    void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "Ball")
        {
            if (GameObject.FindGameObjectsWithTag("Brick").Length==1)
            {
                GameOverManager.Player2Win();
            }
            Score.blocksSmashed += 1;
            Destroy(gameObject);
        }
    }
}
