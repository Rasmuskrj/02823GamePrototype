using UnityEngine;
using System.Collections;

public class Breakout : MonoBehaviour, IGameTypeInterface
{
    public Transform paddle;
    public int score = 0;
    public Camera cam;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MoveX(float axisx)
    {
        
        paddle.localPosition = new Vector3(Mathf.Clamp(paddle.localPosition.x + axisx, -300.5f, 300.5f), -10.0f, 0.0f);
        Debug.Log(paddle.localPosition.x);
        Debug.Log(paddle.position.x);
    }
    public void MoveY(float axisy)
    {

    }
    public void SetCamera(Rect rect)
    {
        cam.rect = rect;
    }
}
