using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public Transform Breakout;
    public Transform Snake;
    public Transform Tetris;
    public InputController inputController;
    private Vector2 gamePos1 = new Vector2 ( -50, 50);
    private Vector2 gamePos2 = new Vector2( 50, 50);
    private Vector2 gamePos3 = new Vector2( -50, -50);
    private Vector2 gamePos4 = new Vector2( 50, -50);
    private IGameTypeInterface game1;
    private IGameTypeInterface game2;
    private IGameTypeInterface game3;
    private IGameTypeInterface game4;


    // Use this for initialization
    void Start () {

        game1 = MakeGame(Tetris, gamePos1, new Rect(0.0f,0.5f,0.5f,0.5f), 1);
        game2 = MakeGame(Breakout, gamePos2, new Rect(0.5f, 0.5f, 0.5f, 0.5f), 2);
        game3 = MakeGame(Breakout, gamePos3, new Rect(0.0f, 0.0f, 0.5f, 0.5f), 3);
        game4 = MakeGame(Breakout, gamePos4, new Rect(0.5f, 0.0f, 0.5f, 0.5f), 4);


        inputController.GameSetup(new IGameTypeInterface[] {game1, game2, game3, game4});
	}
    IGameTypeInterface MakeGame(Transform game, Vector2 pos, Rect rect, uint gameID)
    {
        Transform newGame;
        IGameTypeInterface gameInterface;
        newGame = Instantiate(game);
        newGame.position = pos;
        newGame.rotation = Quaternion.identity;
        gameInterface = newGame.GetComponent<IGameTypeInterface>();
        gameInterface.SetGameID(gameID);
        gameInterface.SetCamera(rect);
        gameInterface.SetGameController(this);
        return gameInterface;
    }
    public void IncreaseDifficulty(uint playerID)
    {
        if (playerID != 1) { game1.IncreaseDifficulty(); }
        if (playerID != 2) { game2.IncreaseDifficulty(); }
        if (playerID != 3) { game3.IncreaseDifficulty(); }
        if (playerID != 4) { game4.IncreaseDifficulty(); }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
