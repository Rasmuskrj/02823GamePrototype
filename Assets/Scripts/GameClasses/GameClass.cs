using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class GameClass : MonoBehaviour {
    public int score = 0;
    public int difficulty = 0;
    public Camera cam;
    public Camera[] otherCams;
    public bool isAI;
    public int gameID;
    public GameController gameController;
    protected uint Tokens = 0;

    //Gui elements
    public Text scoreDisplayed;
    public Text tokensDisplayed;
    public Text difficultyDisplayed;

    /*public GameClass (int ID, Rect camRect, GameController gameCtrl)
    {
        gameID = ID;
        cam.rect = camRect;
        gameController = gameCtrl;
    }*/
    public void Update()
    {
        scoreDisplayed.text = score.ToString();
        tokensDisplayed.text = Tokens.ToString();
        difficultyDisplayed.text = difficulty.ToString();
    }


    public void SetGameID(int ID) { gameID = ID; }
    public void SetCamera(Rect rect) { cam.rect = rect; }
    public void SetGameController(GameController gameCtrl) { gameController = gameCtrl; }
    public void SetOtherCams(Camera[] cams) { otherCams = cams; }
    public bool HasToken() { return (Tokens > 0); }
    public void ReduceTokens() { Tokens--; }
    public void IncreaseDifficultyOnOther() {gameController.IncreaseDifficulty(gameID);}

    public virtual void MoveX(float axisx) { }// needs an overwrite to be of use
    public virtual void MoveY(float axisy) { }// needs an overwrite to be of use
    public virtual void MoveXRaw(float axisy) { }// needs an overwrite to be of use
    public virtual void MoveYRaw(float axisy) { }// needs an overwrite to be of use

    public void DoOnA() { }
    public void DoOnB() { }

    abstract public void IncreaseDifficulty();// { difficulty++; }// needs an subfunction
    abstract public void ReduceDifficulty();// { difficulty--; }// needs an subfunction, we should consider making check so we can't make the game easier that what it is at the start
    

}
