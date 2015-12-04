using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour{
    public Transform[] games;
	public Transform[] gamecol;
	public Transform gameController;
	public string[] gameNames;
    public SubMenu[] subMenus = new SubMenu[4];
	public bool[] isAI = {false, false, false, false};

    public float joystickRate = 0.5f;
    public float joystickMovementThreshhold = 0.6f;
    private Gamepad[] gamepads = { new Gamepad(0), new Gamepad(1), new Gamepad(2), new Gamepad(3) };

    public Text[] leftGameList;
    public Text[] centerGameList;
    public Text[] rightGameList;

    void Start()
    {
        subMenus = new SubMenu[4] { new SubMenu(games.Length,this), new SubMenu(games.Length, this), new SubMenu(games.Length, this), new SubMenu(games.Length, this) };
        UpdateGameList();
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
            if (Mathf.Abs(Input.GetAxisRaw(gamepads[i].xAxis)) > joystickMovementThreshhold) {if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; subMenus[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xAxis)); } }
            else if (Input.GetAxisRaw(gamepads[i].xDpadAxis) != 0) { if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; subMenus[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xDpadAxis)); } }
            else if (Input.GetAxisRaw(gamepads[i].xKey) != 0) { if (gamepads[i].x_isAxisInUse == false) { gamepads[i].x_isAxisInUse = true; subMenus[i].MoveXRaw(Input.GetAxisRaw(gamepads[i].xKey)); } }
            else { gamepads[i].x_isAxisInUse = false; }
            if (Input.GetButton(gamepads[i].TargetKey)) { subMenus[i].selectGame(); }
        }
        
    }
    public void UpdateGameList()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            leftGameList[i].text = gameNames[subMenus[i].leftGame];
            centerGameList[i].text = gameNames[subMenus[i].cenGame];
            rightGameList[i].text = gameNames[subMenus[i].rightGame];
        }
    }
    public void RunCheck()
	{
		if (subMenus[0].isSelected && subMenus[1].isSelected && subMenus[2].isSelected && subMenus[3].isSelected)
		{
            gamecol =  new Transform[] { games[subMenus[0].GetSelectGame()], games[subMenus[1].GetSelectGame()], games[subMenus[2].GetSelectGame()], games[subMenus[3].GetSelectGame()]};
			startGame();
		}
	}
	
	public void startGame ()
	{
		Transform gamectrl;
        
		gamectrl = Instantiate(gameController);
        GameController ctrl = gamectrl.GetComponent<GameController>();
        ctrl.Initializegames(gamecol, isAI);
        Destroy(gameObject);
	}
}
