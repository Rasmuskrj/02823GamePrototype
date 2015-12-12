using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public Transform InputControllerPrefab;
    public ScaleableInputController inputController;
    private Vector2[] gamePos = { new Vector2(-100, 100), new Vector2(100, 100), new Vector2(-100, -100), new Vector2(100, -100) };
    private Vector2[] offsets = { new Vector2(1, 0), new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1) };
    private GameClass[] game;
    public Transform[] gamesToSetup;
    public bool[] isAI;
    public int numOfGames;

    public static GameController Instance
    {
        get;
        private set;
    }

    void Awake(){
        Instance = this;
    }

    // Use this for initialization
    void Start() {
        
        /*gamesToSetup = new Transform[3];
        gamesToSetup[0] = Breakout;
        gamesToSetup[1] = Snake;
        gamesToSetup[2] = Tetris;*/
        //Initializegames(gamesToSetup, isAI);

        
        
	}
    public void Initializegames(Transform[] games, bool[] AIStatus, Gamepad[] newGamepad)
    {
        numOfGames = games.Length;
        Transform input = Instantiate(InputControllerPrefab);
        inputController = input.GetComponent<ScaleableInputController>();
        inputController.gameController = this;
        game = new GameClass[games.Length];
        Rect[] campos = GetCameraPositions(games.Length);
        for (int i = 0; i < games.Length; i++)
        {
            game[i] = MakeGame(games[i], gamePos[i], campos[i], i, offsets[i], AIStatus[i]);
        }
        Camera[] camCol = new Camera[game.Length];
        for (int i = 0; i < games.Length; i++)
        {
            camCol[i] = game[i].cam;
        }
        for (int i = 0; i < games.Length; i++)
        {
            Camera[] otherCams = new Camera[game.Length-1];
            int j = 0;
            for (int k = 0; k < games.Length-1; k++)
            {
                if (i == j) { j++; }
                otherCams[k] = game[j].cam;
                j++;
            }
            game[i].SetOtherCams(otherCams);
        }
        inputController.GameSetup(game, newGamepad);
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
    GameClass MakeGame(Transform game, Vector2 pos, Rect rect, int gameID, Vector2 offset, bool AIStatus)
    {
        Transform newGame;
        GameClass gameInterface;
        newGame = Instantiate(game);
        newGame.position = pos;
        newGame.rotation = Quaternion.identity;
        gameInterface = newGame.GetComponent<GameClass>();
        gameInterface.SetGameID(gameID);
        gameInterface.SetCamera(rect);
        gameInterface.SetGameController(this);
        gameInterface.SetPanel(offset);
        gameInterface.isAI = AIStatus;
        gameInterface.gameID = gameID;
        return gameInterface;
    }
    public void IncreaseDifficulty(int playerID)
    {
        for (int i = 0; i < game.Length; i++)
        {
            if (playerID != i) { game[i].IncreaseDifficulty(); }
        }
    }
    public void IncreaseDifficultyOnPlayer(int sendingPlayer, int targetPlayer)
    {
        if (sendingPlayer == targetPlayer)
        {
            game[targetPlayer].ReduceDifficulty();
        }
        else
        {
            game[targetPlayer].IncreaseDifficulty();
        }
    }
	// Update is called once per frame
	void Update () {
    }

    public GameClass[] GetGames()
    {
        return game;
    }
}
