using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TetrisBlock {
    public struct CoOrd
    {
        public int xCord;
        public int yCord;

        public CoOrd(int x, int y)
        {
            xCord = x;
            yCord = y;
        }
    }

    private bool moving = true;
    public CoOrd pos;
    public CoOrd[] additionalPos;

	// Use this for initialization
	public TetrisBlock () {

	}

    public void CalculateAdditionalPos()
    {
        additionalPos = new CoOrd[3];
        additionalPos[0] = new CoOrd(pos.xCord + 1, pos.yCord);
        additionalPos[1] = new CoOrd(pos.xCord, pos.yCord + 1);
        additionalPos[2] = new CoOrd(pos.xCord, pos.yCord + 2);
    }

    public CoOrd[] GetInhabitedCoords()
    {
        CoOrd[] returnArr = new CoOrd[additionalPos.Length + 1];
        returnArr[0] = pos;
        for (int i = 1; i < additionalPos.Length + 1; i++)
        {
            returnArr[i] = additionalPos[i - 1];
        }
        return returnArr;
    }
	


}
