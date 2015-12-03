using UnityEngine;
using System.Collections;

public class SubMenu{
    public int numGames;
	
	public string[] gameNames;
    private int leftGame = 0;
	private int cenGame = 1;
	private int rightGame = 2;
	public bool isSelected = false;
	public SubMenu (int numOfGames)
    {
        numGames = numOfGames;
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
	}
	public int GetSelectGame()
	{
		return cenGame;
	}
	public void selectGame()
	{
		isSelected = true;
	}
	public void unSelectGame()
	{
		isSelected = false;
	}
}
