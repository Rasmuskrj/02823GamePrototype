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


    // Use this for initialization
    void Start () {
        inputController.GameSetup(new IGameTypeInterface[] {MakeGame(Breakout, gamePos1),
                                                            MakeGame(Breakout, gamePos2),
                                                            MakeGame(Snake, gamePos3),
                                                            MakeGame(Snake, gamePos4) });
	}
    IGameTypeInterface MakeGame(Transform game, Vector2 pos)
    {
        Transform newGame;
        newGame = Instantiate(game);
        newGame.position = pos;
        newGame.rotation = Quaternion.identity;
        return newGame.GetComponent<IGameTypeInterface>();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
