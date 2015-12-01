using UnityEngine;
using System.Collections;

public class Breakout : GameClass
{
    public GameObject paddle;
    public Ball ball;
    public BreakoutBlockSpawner breakoutBlockSpawner;
    public int lives = 3;
    private int progressOnToken = 0;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	    if (isAI) { paddle.transform.localPosition = new Vector3(Mathf.Clamp(ball.transform.localPosition.x, -13.5f, 13.5f), -10.0f, 0.0f); }
	}
    public override void MoveX(float axisx)
    {
        paddle.transform.localPosition = new Vector3(Mathf.Clamp(paddle.transform.localPosition.x + axisx, -13.5f, 13.5f), -10.0f, 0.0f);
    }
    override public void IncreaseDifficulty()
    {
        difficulty++;
        ball.IncreaseMag();
    }
    override public void ReduceDifficulty()
    {
        if (difficulty == 0) { Tokens++; return; }
        difficulty--;
        ball.ReduceMag();
    }

    public void RunOnDestroyedBlock ()
    {
        progressOnToken += 7;
        if (progressOnToken >= 100) { Tokens++; progressOnToken -= 100; }
        if (breakoutBlockSpawner.transform.childCount == 1)
        {
            /*IncreaseDifficultyOnOther();
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
            }*/
            
            breakoutBlockSpawner.SpawnLine();
            breakoutBlockSpawner.SpawnLine();
            ball.ResetBallPos();
            
        }
    }
}
