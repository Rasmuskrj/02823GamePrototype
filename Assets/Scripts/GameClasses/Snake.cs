using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour, IGameTypeInterface
{
    public Vector2 dir = Vector2.right;
    public SnakeHead snakeHead;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MoveX(float axisx)
    {

        if (axisx > 0.5f && dir != Vector2.left)
            dir = Vector2.right;
        else if (axisx<0.5f && dir != Vector2.right)
            dir = -Vector2.right; // '-right' means 'left'
        snakeHead.SetDir(dir);
        }
    public void MoveY(float axisy)
    {
        if (axisy > 0.5f && dir != -Vector2.up)
            dir = Vector2.up;
        else if (axisy<0.5f && dir != Vector2.up)
            dir = -Vector2.up;    // '-up' means 'down'
        snakeHead.SetDir(dir);

    }
}
