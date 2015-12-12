using UnityEngine;
using System.Collections;

public class SubMenu{
    public int numGames;
	
	public string[] gameNames;
    public int topTopGame = 4;
    public int topGame = 0;
    public int cenGame = 1;
    public int botGame = 2;
    public int botBotGame = 2;
    public bool isSelected = false;
    private Menu menu;
    public int playertype = 0;

    public RectTransform Selectorplacement;

    public SubMenu (int numOfGames, Menu menuRef)
    {
        menu = menuRef;
        numGames = numOfGames;
    }
    public void MoveXRaw(float axisx)
    {
        if (axisx > 0) { moveRight(); }
        else { moveLeft(); }
    }
    public void MoveYRaw(float axisy)
    {
        if (axisy > 0) { moveUp(); }
        else { moveDown(); }
    }
    public void moveUp()
	{
        botBotGame = botGame;
        botGame = cenGame;
        cenGame = topGame;
        topGame = topTopGame;
		if (topTopGame == numGames-1)
		{
			topTopGame = 0;
		}
		else
		{
			topTopGame++;
		}
        menu.UpdateGameList();
	}
	public void moveDown()
	{
        topTopGame = topGame;
        topGame = cenGame;
        cenGame = botGame;
        botGame = botBotGame;
		if (botBotGame == 0)
		{
            botBotGame = numGames-1;
		}
		else
		{
            botBotGame--;
		}
        menu.UpdateGameList();
    }
    public void moveRight()
    {
        playertype++;
        if (playertype == 3) { playertype = 0; }
        UpdateSelectedGame();
    }
    public void moveLeft()
    {
        playertype--;
        if (playertype == -1) { playertype = 2; }
        UpdateSelectedGame();
    }
    public int GetSelectGame()
	{
		return cenGame;
	}
	public void selectGame()
	{
		isSelected = true;
        menu.RunCheck();
	}
	public void unSelectGame()
	{
		isSelected = false;
	}
    public void UpdateSelectedGame()
    {
        Selectorplacement.localPosition = new Vector3( -220f+60f*playertype,0f);
    }
}
