using UnityEngine;
using System.Collections;

public class ScaleableInputController : MonoBehaviour {

    private IGameTypeInterface[] game;
    private IGameTypeInterface game1;

    private bool[] x_isAxisInUse = { false, false, false, false };
    private bool[] y_isAxisInUse = { false, false, false, false };
    private string[] xControlNames = { "P1Horizontal", "P2Horizontal", "P3Horizontal", "P4Horizontal" };
    private string[] yControlNames = { "P1Vertical", "P2Vertical" , "P3Vertical" , "P4Vertical" };

    // Use this for initialization
    void Start () {
    }
    public void GameSetup(IGameTypeInterface[] games)
    {
        game = games;
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i< game.Length; i++)
        {
            if (Input.GetAxisRaw(xControlNames[i]) != 0) { game[i].MoveX(Input.GetAxis(xControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xControlNames[i])); } }
            else { x_isAxisInUse[i] = false; }
            if (Input.GetAxisRaw(yControlNames[i]) != 0) { game[i].MoveY(Input.GetAxis(yControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yControlNames[i])); } }
            else { y_isAxisInUse[i] = false; }
        }
    }
}