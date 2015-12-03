﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour{
    public Transform[] games;
	public Transform[] gamecol;
	public Transform gameController;
	public Transform inputController;
	public string[] gameNames;
    public SubMenu[] subMenus;
	public bool[] isAI = {false, false, false, false};
    
    void Start()
    {
        subMenus = new SubMenu[4] { new SubMenu(games.Length), new SubMenu(games.Length), new SubMenu(games.Length), new SubMenu(games.Length) };
        // test function
        for (int i = 0; i < subMenus.Length; i++)
        {
            int k = (int)Random.Range(0f, 100f);
            for (int j = 0; j < k; j++)
            {
                subMenus[i].moveLeft();
            }
            subMenus[i].selectGame();
        }
    }


	void Update()
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
        gamectrl.GetComponent<GameController>().Initializegames(gamecol, isAI);
        Destroy(gameObject);
	}
}
