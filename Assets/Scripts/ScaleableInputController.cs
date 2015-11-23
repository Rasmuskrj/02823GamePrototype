using UnityEngine;
using System.Collections;

public class ScaleableInputController : MonoBehaviour {

    private IGameTypeInterface[] game;
    private IGameTypeInterface game1;

    public float joystickRate = 0.5f;
    public float joystickMovementThreshhold = 0.6f;

    private bool[] x_isAxisInUse = { false, false, false, false };
    private bool[] y_isAxisInUse = { false, false, false, false };
    private string[] xControlNames = { "P1Horizontal", "P2Horizontal", "P3Horizontal", "P4Horizontal" };
    private string[] yControlNames = { "P1Vertical", "P2Vertical" , "P3Vertical" , "P4Vertical" };
    private string[] xKeyControlNames = { "P1HorizontalKey", "P2HorizontalKey", "P3HorizontalKey", "P4HorizontalKey" };
    private string[] yKeyControlNames = { "P1VerticalKey", "P2VerticalKey", "P3VerticalKey", "P4VerticalKey" };

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
            if (Mathf.Abs(Input.GetAxisRaw(xControlNames[i])) > joystickMovementThreshhold) { game[i].MoveX(joystickRate * Input.GetAxis(xControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xControlNames[i])); } }
            else if (Input.GetAxisRaw(xKeyControlNames[i]) != 0) { game[i].MoveX(Input.GetAxis(xKeyControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xKeyControlNames[i])); } }
            else { x_isAxisInUse[i] = false; }
            if (Mathf.Abs(Input.GetAxisRaw(yControlNames[i])) > joystickMovementThreshhold) { game[i].MoveY(joystickRate * Input.GetAxis(yControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yControlNames[i])); } }
            else if (Input.GetAxisRaw(yKeyControlNames[i]) != 0) { game[i].MoveY(Input.GetAxis(yKeyControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yKeyControlNames[i])); } }
            else { y_isAxisInUse[i] = false; }
        }
    }
}