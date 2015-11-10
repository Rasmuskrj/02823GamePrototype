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
    public int noOfOffsets;
    public CoOrd[] offsets;

	// Use this for initialization
	public TetrisBlock () {
        GetOffsets();
	}

    public void CalculateAdditionalPos()
    {
        additionalPos = new CoOrd[noOfOffsets];
        for (int i = 0; i < additionalPos.Length; i++)
        {
            additionalPos[i] = new CoOrd(pos.xCord + offsets[i].xCord, pos.yCord + offsets[i].yCord);
        }
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

    public List<CoOrd> GetLowestYCoOrds()
    {
        CoOrd[] checkArr = GetInhabitedCoords();
        List<CoOrd> returnArr = new List<CoOrd>();
        int lowestY = 10000;
        for (int i = 0; i < checkArr.Length; i++)
        {
            if (checkArr[i].yCord < lowestY)
            {
                lowestY = checkArr[i].yCord;
            }
        }
        for (int i = 0; i < checkArr.Length; i++)
        {
            if (checkArr[i].yCord == lowestY)
            {
                returnArr.Add(checkArr[i]);
            }
        }
        return returnArr;
    }

    public bool CheckOutOfBounds(int limit, bool left)
    {
        for (int i = 0; i < additionalPos.Length; i++)
        {
            if(left){
                if (additionalPos[i].xCord - 1 <= limit)
                {
                    //Debug.Log(additionalPos[i].xCord - 1 > limit);
                    return false;
                }
            }
            else
            {
                if (additionalPos[i].xCord + 1 >= limit)
                {
                    //Debug.Log(additionalPos[i].xCord - 1 > limit);
                    return false;
                }
            }
        }
        return true;
    }

    public bool CheckIfCoOrdInBlock(CoOrd coord)
    {
        if (pos.xCord == coord.xCord && pos.yCord == coord.yCord)
        {
            return true;
        }
        for (int i = 0; i < additionalPos.Length; i++)
        {
            if (additionalPos[i].xCord == coord.xCord && additionalPos[i].yCord == coord.yCord)
            {
                return true;
            }
        }
        return false;
    }

    public void GetOffsets()
    {
        int selector = Random.Range(0, 4);
        if (selector == 0)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(1, 0);
            offsets[1] = new CoOrd(0, 1);
            offsets[2] = new CoOrd(0, 2);
        }
        else if (selector == 1)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, 1);
            offsets[1] = new CoOrd(0, 2);
            offsets[2] = new CoOrd(0, 3);
        }
        else if (selector == 2)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, 1);
            offsets[1] = new CoOrd(1, 0);
            offsets[2] = new CoOrd(1, 1);
        }
        else if (selector == 3)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, 1);
            offsets[1] = new CoOrd(1, 1);
            offsets[2] = new CoOrd(-1, 1);
        }
        else if (selector == 4)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(-1, 0);
            offsets[1] = new CoOrd(0, 1);
            offsets[2] = new CoOrd(0, 2);
        }
    }

}
