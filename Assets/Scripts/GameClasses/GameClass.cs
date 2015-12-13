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
    public RectTransform panel;
    public bool hasLost = false;
    //Gui elements
    public Text playerTitle;
    public Text scoreDisplayed;
    public Text tokensDisplayed;
    public Text difficultyDisplayed;
    public float minWidth;

    /*public GameClass (int ID, Rect camRect, GameController gameCtrl)
    {
        gameID = ID;
        cam.rect = camRect;
        gameController = gameCtrl;
    }*/
    void Awake()
    {
        InvokeRepeating("UpdateUI", 0, 0.5f);
        
    }
    

    public void UpdateUI()
    {
        playerTitle.text = "Player " + (gameID + 1);
        scoreDisplayed.text = score.ToString();
        tokensDisplayed.text = Tokens.ToString();
        difficultyDisplayed.text = difficulty.ToString();
    }
    public void AIUseToken()
    {
        int othergame = (int)Random.Range(0, gameController.numOfGames);
        while (othergame == gameID) { othergame = (int)Random.Range(0, gameController.numOfGames); }
        gameController.IncreaseDifficultyOnPlayer(gameID, othergame);
        Tokens--;
    }

    public void playerLost()
    {
        hasLost = true;
        gameController.runLostCheck();
    }

    public void SetGameID(int ID) { gameID = ID; }
    public void SetCamera(Rect rect) { cam.rect = rect; cam.orthographicSize = Mathf.Max(cam.orthographicSize, minWidth / cam.aspect);}
    public void SetGameController(GameController gameCtrl) { gameController = gameCtrl; }
    public void SetOtherCams(Camera[] cams) { otherCams = cams; }
    public bool HasToken() { return (Tokens > 0); }
    public void ReduceTokens() { Tokens--; }
    public void IncreaseDifficultyOnOther() {gameController.IncreaseDifficulty(gameID);}

    public virtual void MoveX(float axisx) { }// needs an overwrite to be of use
    public virtual void MoveY(float axisy) { }// needs an overwrite to be of use
    public virtual void MoveXRaw(float axisy) { }// needs an overwrite to be of use
    public virtual void MoveYRaw(float axisy) { }// needs an overwrite to be of use

    public virtual void DoOnA() { }
    public virtual void DoOnB() { }

    abstract public void IncreaseDifficulty();// { difficulty++; }// needs an subfunction
    abstract public void ReduceDifficulty();// { difficulty--; }// needs an subfunction, we should consider making check so we can't make the game easier that what it is at the start
    
    public void SetPanel (Vector2 offset)
    {
        panel.anchorMin = new Vector2(offset.x, offset.y);
        panel.anchorMax = new Vector2(offset.x, offset.y);
        panel.anchoredPosition = new Vector2(-140*offset.x,-120 * offset.y);
    }

}
