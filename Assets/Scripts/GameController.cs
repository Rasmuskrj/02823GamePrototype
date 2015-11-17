using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public Transform Breakout;
    public Transform Snake;
    public Transform Tetris;
    public ScaleableInputController inputController;
    private Vector2[] gamePos = { new Vector2(-50, 50), new Vector2(50, 50), new Vector2(-50, -50), new Vector2(50, -50) };
    private IGameTypeInterface[] game;


    // Use this for initialization
    void Start() {
        Transform[] gamesToSetup = new Transform[2];
        gamesToSetup[0] = Breakout;
        gamesToSetup[1] = Tetris; 
        Initializegames(gamesToSetup);

        inputController.GameSetup(game);
        
	}
    void Initializegames(Transform[] games)
    {
        game = new IGameTypeInterface[games.Length];
        Rect[] campos = GetCameraPositions(games.Length);
        for (int i = 0; i < games.Length; i++)
        {
            game[i] = MakeGame(games[i], gamePos[i], campos[i], 1);
        }
    }
    Rect[] GetCameraPositions(int numberOfPlayers)
    {
        switch (numberOfPlayers)
        {
            case 1:
                return new Rect[1] { new Rect(0.0f, 0.0f, 1f, 1f) };
            case 2:
                return new Rect[2] { new Rect(0.0f, 0.0f, 0.5f, 1f), new Rect(0.5f, 0.0f, 0.5f, 1f)};
            case 3:
                return new Rect[3] { new Rect(0.0f, 0.5f, 0.5f, 0.5f), new Rect(0.5f, 0.5f, 0.5f, 0.5f), new Rect(0.0f, 0.0f, 1.0f, 0.5f)};
            case 4:
                return new Rect[4] { new Rect(0.0f, 0.5f, 0.5f, 0.5f), new Rect(0.5f, 0.5f, 0.5f, 0.5f), new Rect(0.0f, 0.0f, 0.5f, 0.5f),new Rect(0.5f, 0.0f, 0.5f, 0.5f)};
            default:
                return new Rect[4] { new Rect(0.0f, 0.5f, 0.5f, 0.5f), new Rect(0.5f, 0.5f, 0.5f, 0.5f), new Rect(0.0f, 0.0f, 0.5f, 0.5f), new Rect(0.5f, 0.0f, 0.5f, 0.5f) };
        }
            
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
        for (int i = 0; i < game.Length; i++)
        {
            if (playerID != i+1) { game[i].IncreaseDifficulty(); }
        }
    }
	// Update is called once per frame
	void Update () {
    }
}
