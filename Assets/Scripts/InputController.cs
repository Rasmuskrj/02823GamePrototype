using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    private IGameTypeInterface p1Game;
    private IGameTypeInterface p2Game;
    private IGameTypeInterface p3Game;
    private IGameTypeInterface p4Game;

    private bool p1x_isAxisInUse = false;
    private bool p1y_isAxisInUse = false;
    private bool p2x_isAxisInUse = false;
    private bool p2y_isAxisInUse = false;
    private bool p3x_isAxisInUse = false;
    private bool p3y_isAxisInUse = false;
    private bool p4x_isAxisInUse = false;
    private bool p4y_isAxisInUse = false;


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
        if (Input.GetAxisRaw("P1Horizontal") != 0) { p1Game.MoveX(Input.GetAxis("P1Horizontal")); if (p1x_isAxisInUse == false) { p1x_isAxisInUse = true; p1Game.MoveXRaw(Input.GetAxisRaw("P1Horizontal")); } }
        else { p1x_isAxisInUse = false; }
        if (Input.GetAxisRaw("P1Vertical") != 0) { p1Game.MoveY(Input.GetAxis("P1Vertical")); if (p1y_isAxisInUse == false) { p1y_isAxisInUse = true; p1Game.MoveYRaw(Input.GetAxisRaw("P1Vertical")); } }
        else { p1y_isAxisInUse = false; }
        if (Input.GetAxisRaw("P2Horizontal") != 0) { p2Game.MoveX(Input.GetAxis("P2Horizontal")); if (p1x_isAxisInUse == false) { p2x_isAxisInUse = true; p2Game.MoveXRaw(Input.GetAxisRaw("P2Horizontal")); } }
        else { p2x_isAxisInUse = false; }
        if (Input.GetAxisRaw("P2Vertical") != 0) { p2Game.MoveY(Input.GetAxis("P2Vertical")); if (p1y_isAxisInUse == false) { p2y_isAxisInUse = true; p2Game.MoveYRaw(Input.GetAxisRaw("P2Vertical")); } }
        else { p2y_isAxisInUse = false; }
        if (Input.GetAxisRaw("P3Horizontal") != 0) { p3Game.MoveX(Input.GetAxis("P3Horizontal")); if (p1x_isAxisInUse == false) { p3x_isAxisInUse = true; p3Game.MoveXRaw(Input.GetAxisRaw("P3Horizontal")); } }
        else { p3x_isAxisInUse = false; }
        if (Input.GetAxisRaw("P3Vertical") != 0) { p3Game.MoveY(Input.GetAxis("P3Vertical")); if (p1y_isAxisInUse == false) { p3y_isAxisInUse = true; p3Game.MoveYRaw(Input.GetAxisRaw("P3Vertical")); } }
        else { p3y_isAxisInUse = false; }
        if (Input.GetAxisRaw("P4Horizontal") != 0) { p4Game.MoveX(Input.GetAxis("P4Horizontal")); if (p1x_isAxisInUse == false) { p4x_isAxisInUse = true; p4Game.MoveXRaw(Input.GetAxisRaw("P4Horizontal")); } }
        else { p4x_isAxisInUse = false; }
        if (Input.GetAxisRaw("P4Vertical") != 0) { p4Game.MoveY(Input.GetAxis("P4Vertical")); if (p1y_isAxisInUse == false) { p4y_isAxisInUse = true; p4Game.MoveYRaw(Input.GetAxisRaw("P4Vertical")); } }
        else { p4y_isAxisInUse = false; }
    }
}