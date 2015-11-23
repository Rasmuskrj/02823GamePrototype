using UnityEngine;
using System.Collections;

public class Breakout : MonoBehaviour, IGameTypeInterface
{
    public GameObject paddle;
    public int score = 0;
    public int difficulty = 0;
    public Camera cam;
    public Ball ball;
    public bool isAI;
    public uint gameID;
    public GameController gameController;
    public BreakoutBlockSpawner breakoutBlockSpawner;
    public int lives = 3;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if (isAI) { paddle.transform.localPosition = new Vector3(Mathf.Clamp(ball.transform.localPosition.x, -3.5f, 3.5f), -10.0f, 0.0f); }
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
        paddle.transform.localPosition = new Vector3(Mathf.Clamp(paddle.transform.localPosition.x + axisx, -3.5f, 3.5f), -10.0f, 0.0f);
    }
    public void MoveY(float axisy)
    {

    }
    public void MoveXRaw(float axisx) { }
    public void MoveYRaw(float axisy) { }
    public void SetCamera(Rect rect)
    {
        cam.rect = rect;
    }
    public void IncreaseDifficulty()
    {
        difficulty++;
        ball.IncreaseMag();
    }
    public void IncreaseDifficultyOnOther()
    {
        gameController.IncreaseDifficulty(gameID);
    }
    public void RunOnDestroyedBlock ()
    {
        Debug.Log(breakoutBlockSpawner.transform.childCount);
        if (breakoutBlockSpawner.transform.childCount == 1)
        {
            IncreaseDifficultyOnOther();
            breakoutBlockSpawner.SpawnLine();
            Debug.Log(Mathf.Min(((int)(difficulty / 5)) - ((int)(difficulty / 10) ), 10));
            for (int i = 0; i< Mathf.Min(((int) (difficulty / 5)) - ((int) (difficulty / 5) - 10), 10); i++)
            {
                breakoutBlockSpawner.DecentLine();
            }
            breakoutBlockSpawner.SpawnLine();
            for (int i = 0; i < Mathf.Min(difficulty / 5-10, 10); i++)
            {
                breakoutBlockSpawner.DecentLine();
            }
            ball.ResetBallPos();
            
        }
    }
}
