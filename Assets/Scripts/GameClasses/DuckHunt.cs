using UnityEngine;
using System.Collections;

public class DuckHunt : MonoBehaviour, IGameTypeInterface {
    public Camera cam;
    public uint gameID;
    public GameController gameController;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetGameID(uint ID)
    {
        gameID = ID;
    }
    public void SetGameController(GameController gameCtrl)
    {
        gameController = gameCtrl;
    }
    public void MoveX(float axisx)
    {

    }
    public void MoveY(float axisy)
    {

    }
    public void MoveXRaw(float axisx){   }
    public void MoveYRaw(float axisy) {    }
    public void SetCamera(Rect rect)
    {
        cam.rect = rect;
    }
    public void IncreaseDifficulty()
    {

    }
    public void IncreaseDifficultyOnOther()
    {
        gameController.IncreaseDifficulty(gameID);
    }
}
