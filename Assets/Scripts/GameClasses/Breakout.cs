using UnityEngine;
using System.Collections;

public class Breakout : MonoBehaviour, IGameTypeInterface
{
    public Transform paddle;
    public int score = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MoveX(float axisx)
    {
        paddle.position = new Vector3(Mathf.Clamp(paddle.position.x + axisx, -3.5f, 3.5f), -10.0f, 0.0f);
    }
    public void MoveY(float axisy)
    {

    }
}
