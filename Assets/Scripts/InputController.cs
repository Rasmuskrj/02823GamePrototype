using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    private IGameTypeInterface p1Game;
    private IGameTypeInterface p2Game;
    private IGameTypeInterface p3Game;
    private IGameTypeInterface p4Game;


    // Use this for initialization
    void Start () {
    }
    public void GameSetup(IGameTypeInterface[] games)
    {
        switch (games.Length)
        {
            default:
                p4Game = games[3];
                goto case 3;
            case 3:
                p3Game = games[2];
                goto case 2;
            case 2:
                p2Game = games[1];
                goto case 1;
            case 1:
                p1Game = games[0];
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Input.GetAxis ("P1Horizontal")) > 0.1f)
        {
            p1Game.MoveX(Input.GetAxis("P1Horizontal"));
            //p1Games[currentP1Game].MoveX(Input.GetAxis("Horrizontal")); //for later use
            
        }
        if (Mathf.Abs(Input.GetAxis("P1Vertical")) > 0.1f)
        {
            p1Game.MoveY(Input.GetAxis("P1Vertical"));
            //p1Games[currentP1Game].MoveY(Input.GetAxis("Vertical")); // for later use
        }
        if (Mathf.Abs(Input.GetAxis("P2Horizontal")) > 0.1f)
        {
            p2Game.MoveX(Input.GetAxis("P2Horizontal"));
            //p1Games[currentP1Game].MoveX(Input.GetAxis("Horrizontal")); //for later use
        }
        if (Mathf.Abs(Input.GetAxis("P2Vertical")) > 0.1f)
        {
            p2Game.MoveY(Input.GetAxis("P2Vertical"));
            //p1Games[currentP1Game].MoveY(Input.GetAxis("Vertical")); // for later use
        }
        if (Mathf.Abs(Input.GetAxis("P3Horizontal")) > 0.1f)
        {
            p3Game.MoveX(Input.GetAxis("P3Horizontal"));
            //p1Games[currentP1Game].MoveX(Input.GetAxis("Horrizontal")); //for later use
        }
        if (Mathf.Abs(Input.GetAxis("P3Vertical")) > 0.1f)
        {
            p3Game.MoveY(Input.GetAxis("P3Vertical"));
            //p1Games[currentP1Game].MoveY(Input.GetAxis("Vertical")); // for later use
        }
        if (Mathf.Abs(Input.GetAxis("P4Horizontal")) > 0.1f)
        {
            p4Game.MoveX(Input.GetAxis("P4Horizontal"));
            //p1Games[currentP1Game].MoveX(Input.GetAxis("Horrizontal")); //for later use
        }
        if (Mathf.Abs(Input.GetAxis("P4Vertical")) > 0.1f)
        {
            p4Game.MoveY(Input.GetAxis("P4Vertical"));
            //p1Games[currentP1Game].MoveY(Input.GetAxis("Vertical")); // for later use
        }
    }
}