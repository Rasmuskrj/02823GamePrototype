using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour, IGameTypeInterface
{
    public Vector2 dir = Vector2.right;
    public SnakeHead snakeHead;
    public Camera cam;
    public uint gameID;
    public GameController gameController;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetGameID(uint ID)
    {
        gameID = ID;
    }
    public void SetGameController(GameController gameCtrl)
    {
        gameController = gameCtrl;
    }
    public void MoveX(float axisx)
    {

        
            
        }
    public void MoveY(float axisy)
    {
        
            

    }
    public void MoveXRaw(float axisx) {
        if (axisx > 0.5f && dir != Vector2.left)
        {
            dir = Vector2.right;
            snakeHead.SetDir(dir);
        }
        else if (axisx < -0.5f && dir != Vector2.right)
        {
            dir = -Vector2.right; // '-right' means 'left'
            snakeHead.SetDir(dir);
        }

    }
    public void MoveYRaw(float axisy) {
        if (axisy > 0.5f && dir != -Vector2.up)
        {
            dir = Vector2.up;
            snakeHead.SetDir(dir);
        }
        else if (axisy < -0.5f && dir != Vector2.up)
        {
            dir = -Vector2.up;    // '-up' means 'down'
            snakeHead.SetDir(dir);
        }
    }
    public void SetCamera(Rect rect)
    {
        cam.rect = rect;
    }

    public void IncreaseDifficulty()
    {
        
    }
    public void IncreaseDifficultyOnOther()
    {
        gameController.IncreaseDifficulty(gameID);
    }
}
