using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject FirstMenu;
    public GameObject PlayAIMenu;
    public Transform Breakout;
    public Transform Tetris;
    public Transform Snake;
    public Transform Shooter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayMultiplayer()
    {
        FirstMenu.SetActive(false);
    }

    public void PlayAI()
    {
        FirstMenu.SetActive(false);
        PlayAIMenu.SetActive(true);
    }

    public void VsAIBreakout()
    {
        GameController.gamesToSetup = new Transform[4];
        GameController.gamesToSetup[0] = Breakout;
        GameController.gamesToSetup[1] = Snake;
        GameController.gamesToSetup[2] = Tetris;
        GameController.gamesToSetup[3] = Shooter;
        ChangeScene();
    }

    public void VsAITetris()
    {
        GameController.gamesToSetup = new Transform[4];
        GameController.gamesToSetup[0] = Tetris;
        GameController.gamesToSetup[1] = Snake;
        GameController.gamesToSetup[2] = Breakout;
        GameController.gamesToSetup[3] = Shooter;
        ChangeScene();
    }

    public void VsAISnake()
    {
        GameController.gamesToSetup = new Transform[4];
        GameController.gamesToSetup[0] = Snake;
        GameController.gamesToSetup[1] = Breakout;
        GameController.gamesToSetup[2] = Tetris;
        GameController.gamesToSetup[3] = Shooter;
        ChangeScene();
    }

    public void VsAIShooter()
    {
        GameController.gamesToSetup = new Transform[4];
        GameController.gamesToSetup[0] = Shooter;
        GameController.gamesToSetup[1] = Snake;
        GameController.gamesToSetup[2] = Tetris;
        GameController.gamesToSetup[3] = Breakout;
        ChangeScene();
    }

    public void ChangeScene()
    {
        Application.LoadLevel("2PlayerScene");
    }
}
