using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    private IGameTypeInterface[] p1Games;
    private IGameTypeInterface[] p2Games;
    private IGameTypeInterface[] p3Games;
    private IGameTypeInterface[] p4Games;
    private int currentP1Game;
    private int currentP2Game;
    private int currentP3Game;
    private int currentP4Game;
    public IGameTypeInterface game;


    // Use this for initialization
    void Start () {
    }
    void GameSetup(IGameTypeInterface[] gameRotation)
    {
        currentP1Game = 0;
        currentP2Game = 0;
        currentP3Game = 0;
        currentP4Game = 0;
        /*
        assosiategames(p1Games, gameRotation[0], gameRotation[1], gameRotation[2], gameRotation[3]);
        assosiategames(p2Games, gameRotation[0], gameRotation[1], gameRotation[2], gameRotation[3]);
        assosiategames(p3Games, gameRotation[0], gameRotation[1], gameRotation[2], gameRotation[3]);
        assosiategames(p4Games, gameRotation[0], gameRotation[1], gameRotation[2], gameRotation[3]);*/ //for later use
    }
    private void assosiategames(IGameTypeInterface[] games, IGameTypeInterface game1, IGameTypeInterface game2, IGameTypeInterface game3, IGameTypeInterface game4)
    {
        games = new IGameTypeInterface[4];
        games[0] = game1;
        games[1] = game2;
        games[2] = game3;
        games[3] = game4;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Mathf.Abs(Input.GetAxis ("Horrizontal")) > 0.1f)
        {
            game.MoveX(Input.GetAxis("Horrizontal"));
            //p1Games[currentP1Game].MoveX(Input.GetAxis("Horrizontal")); //for later use
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            game.MoveY(Input.GetAxis("Vertical"));
            //p1Games[currentP1Game].MoveY(Input.GetAxis("Vertical")); // for later use
        }
    }
}
