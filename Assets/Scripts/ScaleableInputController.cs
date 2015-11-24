﻿using UnityEngine;
using System.Collections;

public class ScaleableInputController : MonoBehaviour {

    private IGameTypeInterface[] game;
    private IGameTypeInterface game1;

    public float joystickRate = 0.5f;

    private bool[] x_isAxisInUse = { false, false, false, false };
    private bool[] y_isAxisInUse = { false, false, false, false };
    private string[] xControlNames = { "P1Horizontal", "P2Horizontal", "P3Horizontal", "P4Horizontal" };
    private string[] yControlNames = { "P1Vertical", "P2Vertical" , "P3Vertical" , "P4Vertical" };
    private string[] xDpadControlNames = { "P1HorizontalDpad", "P2HorizontalDpad", "P3HorizontalDpad", "P4HorizontalDpad" };
    private string[] yDpadControlNames = { "P1VerticalDpad", "P2VerticalDpad", "P3VerticalDpad", "P4VerticalDpad" };
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
            if (Input.GetAxisRaw(xControlNames[i]) != 0) { game[i].MoveX(joystickRate * Input.GetAxis(xControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xControlNames[i])); } }
            else if (Input.GetAxisRaw(xDpadControlNames[i]) != 0) { game[i].MoveX(Input.GetAxis(xDpadControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xDpadControlNames[i])); } }
            else if (Input.GetAxisRaw(xKeyControlNames[i]) != 0) { game[i].MoveX(Input.GetAxis(xKeyControlNames[i])); if (x_isAxisInUse[i] == false) { x_isAxisInUse[i] = true; game[i].MoveXRaw(Input.GetAxisRaw(xKeyControlNames[i])); } }
            else { x_isAxisInUse[i] = false; }
            if (Input.GetAxisRaw(yControlNames[i]) != 0) { game[i].MoveY(joystickRate * Input.GetAxis(yControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yControlNames[i])); } }
            else if (Input.GetAxisRaw(yDpadControlNames[i]) != 0) { game[i].MoveY(Input.GetAxis(yDpadControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yDpadControlNames[i])); } }
            else if (Input.GetAxisRaw(yKeyControlNames[i]) != 0) { game[i].MoveY(Input.GetAxis(yKeyControlNames[i])); if (y_isAxisInUse[i] == false) { y_isAxisInUse[i] = true; game[i].MoveYRaw(Input.GetAxisRaw(yKeyControlNames[i])); } }
            else { y_isAxisInUse[i] = false; }
        }
    }
}