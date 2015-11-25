using UnityEngine;
using System.Collections;

public abstract class GameClass : MonoBehaviour {
    public int score = 0;
    public int difficulty = 0;
    public Camera cam;
    public bool isAI;
    public int gameID;
    public GameController gameController;
    private uint Tokens = 0;

    public void SetCamera(Rect rect) {cam.rect = rect;}
    public void SetGameID(int ID) { gameID = ID; }
    public void SetGameController(GameController gameCtrl) { gameController = gameCtrl; }
    public bool HasToken() { return (Tokens > 0); }
    public void ReduceTokens() { Tokens--; }
    public void IncreaseDifficultyOnOther() {gameController.IncreaseDifficulty(gameID);}

    public void MoveX(float axisx) { }// needs an overwrite to be of use
    public void MoveY(float axisy) { }// needs an overwrite to be of use
    public void MoveXRaw(float axisy) { }// needs an overwrite to be of use
    public void MoveYRaw(float axisy) { }// needs an overwrite to be of use

    public void DoOnA() { }
    public void DoOnB() { }

    abstract public void IncreaseDifficulty();// { difficulty++; }// needs an subfunction
    abstract public void ReduceDifficulty();// { difficulty--; }// needs an subfunction, we should consider making check so we can't make the game easier that what it is at the start
    

}
