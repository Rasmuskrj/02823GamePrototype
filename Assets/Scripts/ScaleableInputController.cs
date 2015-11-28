using UnityEngine;
using System.Collections;

public class ScaleableInputController : MonoBehaviour {

    private GameClass[] game;
    //private IGameTypeInterface game1;

    public GameController gameController;

    public float joystickRate = 0.5f;
    public float joystickMovementThreshhold = 0.6f;
    private Gamepad[] gamepads = { new Gamepad(0), new Gamepad(1) , new Gamepad(2) , new Gamepad(3) };

    

    // Use this for initialization
    void Start () {
    }
    public void GameSetup(GameClass[] games)
    {
        game = games;
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i< game.Length; i++)
        {
            Debug.Log(gamepads[i].xAxis);
            if (Mathf.Abs(Input.GetAxisRaw(gamepads[i].xAxis)) > joystickMovementThreshhold) { game[i].MoveX(joystickRate * Input.GetAxis(gamepads[i].xAxis)); if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; game[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xAxis)); } }
            else if (Input.GetAxisRaw(gamepads[i].xDpadAxis) != 0) { game[i].MoveX(Input.GetAxis(gamepads[i].xDpadAxis)); if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; game[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xDpadAxis)); } }
            else if (Input.GetAxisRaw(gamepads[i].xKey) != 0) { game[i].MoveX(Input.GetAxis(gamepads[i].xKey)); if (gamepads[i].x_isAxisInUse ) { gamepads[i].x_isAxisInUse = true; game[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xKey)); } }
            else { gamepads[i].x_isAxisInUse = false; }
            if (Mathf.Abs(Input.GetAxisRaw(gamepads[i].yAxis)) > joystickMovementThreshhold) { game[i].MoveY(joystickRate * Input.GetAxis(gamepads[i].yAxis)); if (gamepads[i].y_isAxisInUse == false) { gamepads[i].y_isAxisInUse = true; game[i].MoveYRaw(Input.GetAxisRaw(gamepads[i].yAxis)); } }
            else if (Input.GetAxisRaw(gamepads[i].yDpadAxis) != 0) { game[i].MoveY(Input.GetAxis(gamepads[i].yDpadAxis)); if (gamepads[i].y_isAxisInUse == false) { gamepads[i].y_isAxisInUse = true; game[i].MoveYRaw(Input.GetAxisRaw(gamepads[i].yDpadAxis)); } }
            else if (Input.GetAxisRaw(gamepads[i].yKey) != 0) { game[i].MoveY(Input.GetAxis(gamepads[i].yKey)); if (gamepads[i].y_isAxisInUse == false) { gamepads[i].y_isAxisInUse = true; game[i].MoveYRaw(Input.GetAxisRaw(gamepads[i].yKey)); } }
            else { gamepads[i].y_isAxisInUse = false; }
            
            if (Input.GetButton(gamepads[i].aKey) || Input.GetAxisRaw(gamepads[i].yKey) <-0.5f) { game[i].DoOnA(); }
            if (Input.GetButton(gamepads[i].bKey) || Input.GetAxisRaw(gamepads[i].yKey) > 0.5f) { game[i].DoOnB(); }


            if (game[i].HasToken())
            {
                if (Input.GetButton(gamepads[i].LBKey)) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 0); }
                else if (Input.GetButton(gamepads[i].RBKey)) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 1); }
                else if (Input.GetAxisRaw(gamepads[i].LTrigger)>0.5f) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 2); }
                else if (Input.GetAxisRaw(gamepads[i].LTrigger)>0.5f) { game[i].ReduceTokens(); gameController.IncreaseDifficultyOnPlayer(i, 3); }

            }
        }
    }
}