using UnityEngine;
using System.Collections;

public class SubMenu{
    public int numGames;
	
	public string[] gameNames;
    public int leftGame = 0;
    public int cenGame = 1;
    public int rightGame = 2;
	public bool isSelected = false;
    private Menu menu;
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
    public void moveRight()
	{
		leftGame=cenGame;
		cenGame=rightGame;
		if (rightGame == numGames-1)
		{
			rightGame = 0;
		}
		else
		{
			rightGame++;
		}
        menu.UpdateGameList();
	}
	public void moveLeft()
	{
		rightGame=cenGame;
		cenGame=leftGame;
		if (leftGame == 0)
		{
			leftGame = numGames-1;
		}
		else
		{
			leftGame--;
		}
        menu.UpdateGameList();
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
}
