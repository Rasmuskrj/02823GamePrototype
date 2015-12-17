using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour{
    public Transform[] games;
	//public Transform[] gamecol;
	public Transform gameController;
	public string[] gameNames;
    public SubMenu[] subMenus = new SubMenu[4];
	//public bool[] isAI = {false, false, false, false};

    public float joystickRate = 0.5f;
    public float joystickMovementThreshhold = 0.6f;
    private Gamepad[] gamepads = { new Gamepad(0), new Gamepad(1), new Gamepad(2), new Gamepad(3) };

    public Text[] topTopGameList;
    public Text[] topGameList;
    public Text[] centerGameList;
    public Text[] bottomGameList;
    public Text[] bottomBottomGameList;

    public Text[] PressStartText;
    public Text[] Ready;
    
    public RectTransform[] Selectorplacement;

    void Start()
    {
        SoundManager.Instance.MuteMusic();
        subMenus = new SubMenu[4] { new SubMenu(games.Length + 1,this), new SubMenu(games.Length + 1, this), new SubMenu(games.Length + 1, this), new SubMenu(games.Length + 1, this) };
        UpdateGameList();
        for (int i = 0; i < 4; i++) { subMenus[i].Selectorplacement = Selectorplacement[i]; }
        /*// test function
        for (int i = 0; i < subMenus.Length; i++)
        {
            int k = (int)Random.Range(0f, 100f);
            for (int j = 0; j < k; j++)
            {
                subMenus[i].moveLeft();
            }
            subMenus[i].selectGame();
        }*/
    }
    void Update()
    {
        for (int i = 0; i < gamepads.Length; i++)
        {
            if (!subMenus[i].isSelected)
            {
                if (Mathf.Abs(Input.GetAxisRaw(gamepads[i].xAxis)) > joystickMovementThreshhold) { if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; subMenus[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xAxis)); } }
                else if (Input.GetAxisRaw(gamepads[i].xDpadAxis) != 0) { if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; subMenus[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xDpadAxis)); } }
                else if (Input.GetAxisRaw(gamepads[i].xKey) != 0) { if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; subMenus[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xKey)); } }
                else { gamepads[i].x_isAxisInUse = false; }
                if (Mathf.Abs(Input.GetAxisRaw(gamepads[i].yAxis)) > joystickMovementThreshhold) { if (gamepads[i].y_isAxisInUse == false) { gamepads[i].y_isAxisInUse = true; subMenus[i].MoveYRaw(Input.GetAxisRaw(gamepads[i].yAxis)); } }
                else if (Input.GetAxisRaw(gamepads[i].yDpadAxis) != 0) { if (gamepads[i].y_isAxisInUse == false) { gamepads[i].y_isAxisInUse = true; subMenus[i].MoveYRaw(Input.GetAxisRaw(gamepads[i].yDpadAxis)); } }
                else if (Input.GetAxisRaw(gamepads[i].yKey) != 0) { if (gamepads[i].y_isAxisInUse == false) { gamepads[i].y_isAxisInUse = true; subMenus[i].MoveYRaw(Input.GetAxisRaw(gamepads[i].yKey)); } }
                else { gamepads[i].y_isAxisInUse = false; }
                if (Input.GetButton(gamepads[i].TargetKey)||Input.GetButton(gamepads[i].aKey)) { subMenus[i].selectGame(); }
            }
        }
        
    }
    public void UpdateGameList()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            topTopGameList[i].text = gameNames[subMenus[i].topTopGame];
            topGameList[i].text = gameNames[subMenus[i].topGame];
            centerGameList[i].text = gameNames[subMenus[i].cenGame];
            bottomGameList[i].text = gameNames[subMenus[i].botGame];
            bottomBottomGameList[i].text = gameNames[subMenus[i].botBotGame];
        }
    }
    
    public void RunCheck()
	{
        SoundManager.Instance.MuteMusic();
        for (int i = 0; i < subMenus.Length; i++)
        {
            if (subMenus[i].isSelected)
            {
                PressStartText[i].color = new Color(0f, 0f, 0f, 0f);
                Ready[i].color = new Color(0f, 0f, 0f, 255f);
            }
            else
            {
                PressStartText[i].color = new Color(0f, 0f, 0f, 255f);
                Ready[i].color = new Color(0f, 0f, 0f, 0f);
            }
                
        }
		if (subMenus[0].isSelected && subMenus[1].isSelected && subMenus[2].isSelected && subMenus[3].isSelected)
		{
            int numOfGames = 0;
            for (int i = 0; i < subMenus.Length; i++)
            {
                if (subMenus[i].playertype != 0)
                {
                    numOfGames++;
                }
            }
            bool[] isAI = new bool[numOfGames];
            Gamepad[] newGamepads = new Gamepad[numOfGames];
            Transform[] gamesToMake = new Transform[numOfGames];
            int j = 0;
            for (int i = 0; i < subMenus.Length; i++)
            {
                
                if (subMenus[i].playertype == 0) { continue; }
                else { newGamepads[j] = gamepads[i]; }
                if (subMenus[i].playertype == 2) { isAI[j] = true; }
                int GametoSet = 0;
                if (subMenus[i].GetSelectGame() == 4) { GametoSet = Random.Range(0, 3); }
                else { GametoSet = subMenus[i].GetSelectGame(); }
                gamesToMake[j] = games[GametoSet];
                j++;
            }
            //gamecol =  new Transform[] { games[subMenus[0].GetSelectGame()], games[subMenus[1].GetSelectGame()], games[subMenus[2].GetSelectGame()], games[subMenus[3].GetSelectGame()]};
			startGame(isAI, newGamepads, gamesToMake);
		}
	}
	
	public void startGame (bool[] isAI, Gamepad[] newGamepads, Transform[] gamesToMake)
	{
        if (gamesToMake.Length == 0) { Application.LoadLevel("MenuScene"); }
        Transform gamectrl;
        
		gamectrl = Instantiate(gameController);
        GameController ctrl = gamectrl.GetComponent<GameController>();
        ctrl.Initializegames(gamesToMake, isAI, newGamepads);
        SoundManager.Instance.UnmuteMusic();
        SoundManager.Instance.SetMusicFrequency(200);
        Destroy(gameObject);
	}
}
