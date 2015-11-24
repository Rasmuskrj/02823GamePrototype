using UnityEngine;
using System.Collections;

public class ScaleableInputController : MonoBehaviour {

    private IGameTypeInterface[] game;
    private IGameTypeInterface game1;

    public GameController gameController;

    public float joystickRate = 0.5f;
    public float joystickMovementThreshhold = 0.6f;

    private bool[] x_isAxisInUse = { false, false, false, false };
    private bool[] y_isAxisInUse = { false, false, false, false };
    private string[] xControlNames = { "P1Horizontal", "P2Horizontal", "P3Horizontal", "P4Horizontal" };
    private string[] yControlNames = { "P1Vertical", "P2Vertical" , "P3Vertical" , "P4Vertical" };
    private string[] xDpadControlNames = { "P1HorizontalDpad", "P2HorizontalDpad", "P3HorizontalDpad", "P4HorizontalDpad" };
    private string[] yDpadControlNames = { "P1VerticalDpad", "P2VerticalDpad", "P3VerticalDpad", "P4VerticalDpad" };
    private string[] xKeyControlNames = { "P1HorizontalKey", "P2HorizontalKey", "P3HorizontalKey", "P4HorizontalKey" };
    private string[] yKeyControlNames = { "P1VerticalKey", "P2VerticalKey", "P3VerticalKey", "P4VerticalKey" };

    private string[] aKeyControlNames = { "P1VerticalKey", "P2VerticalKey", "P3VerticalKey", "P4VerticalKey" };
    private string[] bKeyControlNames = { "P1VerticalKey", "P2VerticalKey", "P3VerticalKey", "P4VerticalKey" };

    private string[] LBKeyControlNames = { "P1LBKey", "P2LBKey", "P3LBKey", "P4LBKey" };
    private string[] RBKeyControlNames = { "P1RBKey", "P2RBKey", "P3RBKey", "P4RBKey" };
    private string[] LTrigKeyControlNames = { "P1LTrigKey", "P2LTrigKey", "P3LTrigKey", "P4LTrigKey" };
    private string[] RTrigKeyControlNames = { "P1RTrigKey", "P2RTrigKey", "P3RTrigKey", "P4RTrigKey" };

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
            else if (Input.GetAxisRaw(xDpadControlNames[i]) != 0) { game[i].MoveX(Input.GetAxis(xDpadControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xDpadControlNames[i])); } }
            else if (Input.GetAxisRaw(xKeyControlNames[i]) != 0) { game[i].MoveX(Input.GetAxis(xKeyControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xKeyControlNames[i])); } }
            else { x_isAxisInUse[i] = false; }
            if (Mathf.Abs(Input.GetAxisRaw(yControlNames[i])) > joystickMovementThreshhold) { game[i].MoveY(joystickRate * Input.GetAxis(yControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yControlNames[i])); } }
            else if (Input.GetAxisRaw(yDpadControlNames[i]) != 0) { game[i].MoveY(Input.GetAxis(yDpadControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yDpadControlNames[i])); } }
            else if (Input.GetAxisRaw(yKeyControlNames[i]) != 0) { game[i].MoveY(Input.GetAxis(yKeyControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yKeyControlNames[i])); } }
            else { y_isAxisInUse[i] = false; }
            
            if (game[i].HasToken())
            {
                if (Input.GetButton(LBKeyControlNames[i])) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 0); }
                else if (Input.GetButton(RBKeyControlNames[i])) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 1); }
                else if (Input.GetButton(LTrigKeyControlNames[i])) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 2); }
                else if (Input.GetButton(RTrigKeyControlNames[i])) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 3); }

            }
        }
    }
}