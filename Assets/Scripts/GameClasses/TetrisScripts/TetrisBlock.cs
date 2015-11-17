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
    public enum Shapes { LShape, IShape, CubeShape, TShape, JShape}
    public Shapes shape;
    public int rotation = 0;

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

    public bool CheckOutOfBounds(int limit, bool left, TetrisController.mapVal[,] map)
    {
        CoOrd[] coords = GetInhabitedCoords();
        for (int i = 0; i < coords.Length; i++)
        {
            if(left){
                if (coords[i].xCord - 1 < limit || (map[coords[i].xCord - 1, coords[i].yCord].cubeInPos && !CheckIfCoOrdInBlock(new CoOrd(coords[i].xCord - 1, coords[i].yCord))))
                {
                    //Debug.Log(additionalPos[i].xCord - 1 > limit);
                    return false;
                }
            }
            else
            {
                if (coords[i].xCord + 1 >= limit || (map[coords[i].xCord + 1, coords[i].yCord].cubeInPos && !CheckIfCoOrdInBlock(new CoOrd(coords[i].xCord + 1, coords[i].yCord))))
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

    public void RotateBlock(int limit, TetrisController.mapVal[,] map)
    {
        switch (shape)
        {
            case Shapes.LShape:
                CoOrd[] verticalOffsets = new CoOrd[3];
                CoOrd[] horizontalOffsets = new CoOrd[3];

                verticalOffsets[0] = new CoOrd(0, 1);
                verticalOffsets[1] = new CoOrd(0, -1);
                verticalOffsets[2] = new CoOrd(1, -1);

                horizontalOffsets[0] = new CoOrd(1, 0);
                horizontalOffsets[1] = new CoOrd(-1, 0);
                horizontalOffsets[2] = new CoOrd(-1, -1);

                SetRotationOffsets(verticalOffsets, horizontalOffsets, limit, map);
                break;
            case Shapes.IShape:
                verticalOffsets = new CoOrd[3];
                horizontalOffsets = new CoOrd[3];

                verticalOffsets[0] = new CoOrd(0, -1);
                verticalOffsets[1] = new CoOrd(0, 1);
                verticalOffsets[2] = new CoOrd(0, 2);

                horizontalOffsets[0] = new CoOrd(-1, 0);
                horizontalOffsets[1] = new CoOrd(1, 0);
                horizontalOffsets[2] = new CoOrd(2, 0);

                SetRotationOffsets(verticalOffsets, horizontalOffsets, limit, map);
                break;
            case Shapes.CubeShape:
                //Do nothing
                break;
            case Shapes.TShape:
                verticalOffsets = new CoOrd[3];
                horizontalOffsets = new CoOrd[3];

                verticalOffsets[0] = new CoOrd(0, -1);
                verticalOffsets[1] = new CoOrd(1, 0);
                verticalOffsets[2] = new CoOrd(-1, 0);

                horizontalOffsets[0] = new CoOrd(0, -1);
                horizontalOffsets[1] = new CoOrd(0, 1);
                horizontalOffsets[2] = new CoOrd(-1, 0);

                SetRotationOffsets(verticalOffsets, horizontalOffsets, limit, map);
                break;
            case Shapes.JShape:
                verticalOffsets = new CoOrd[3];
                horizontalOffsets = new CoOrd[3];

                verticalOffsets[0] = new CoOrd(0, 1);
                verticalOffsets[1] = new CoOrd(0, -1);
                verticalOffsets[2] = new CoOrd(-1, -1);

                horizontalOffsets[0] = new CoOrd(1, 0);
                horizontalOffsets[1] = new CoOrd(-1, 0);
                horizontalOffsets[2] = new CoOrd(-1, 1);

                SetRotationOffsets(verticalOffsets, horizontalOffsets, limit, map);
                break;
        }
    }

    public void GetOffsets()
    {
        int selector = Random.Range(0, 5);
        if (selector == 0)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, 1);
            offsets[1] = new CoOrd(0, -1);
            offsets[2] = new CoOrd(1, -1);
            shape = Shapes.LShape;
        }
        else if (selector == 1)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, -1);
            offsets[1] = new CoOrd(0, 1);
            offsets[2] = new CoOrd(0, 2);
            shape = Shapes.IShape;
        }
        else if (selector == 2)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, 1);
            offsets[1] = new CoOrd(1, 0);
            offsets[2] = new CoOrd(1, 1);
            shape = Shapes.CubeShape;
        }
        else if (selector == 3)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, -1);
            offsets[1] = new CoOrd(1, 0);
            offsets[2] = new CoOrd(-1, 0);
            shape = Shapes.TShape;
        }
        else if (selector == 4)
        {
            noOfOffsets = 3;
            offsets = new CoOrd[noOfOffsets];
            offsets[0] = new CoOrd(0, 1);
            offsets[1] = new CoOrd(0, -1);
            offsets[2] = new CoOrd(-1, -1);
            shape = Shapes.JShape;
        }
    }

    public bool CheckIfCoordsAreFree(CoOrd[] coords,int width,TetrisController.mapVal[,] map)
    {
        for (int i = 0; i < coords.Length; i++)
        {
            if (pos.xCord + coords[i].xCord < 0 ||
                pos.xCord + coords[i].xCord >= width ||
                map[pos.xCord + coords[i].xCord, pos.yCord + coords[i].yCord].cubeInPos 
                && !CheckIfCoOrdInBlock(new CoOrd(pos.xCord + coords[i].xCord, pos.yCord + coords[i].yCord)))
            {
                return false;
            }
        }
        return true;
    }

    private void SetRotationOffsets(CoOrd[] verticalOffsets, CoOrd[] horizontalOffsets, int limit, TetrisController.mapVal[,] map)
    {
        if (rotation == 0 && CheckIfCoordsAreFree(horizontalOffsets, limit, map))
        {
            for (int i = 0; i < offsets.Length; i++)
            {
                offsets[i] = horizontalOffsets[i];
            }
            rotation = 90;
        }
        else if (rotation == 90)
        {
            CoOrd[] flippedCoords = new CoOrd[3];
            for (int i = 0; i < flippedCoords.Length; i++)
            {
                flippedCoords[i].xCord = verticalOffsets[i].xCord * -1;
                flippedCoords[i].yCord = verticalOffsets[i].yCord * -1;
            }
            if (CheckIfCoordsAreFree(flippedCoords, limit, map))
            {
                for (int i = 0; i < offsets.Length; i++)
                {
                    offsets[i] = flippedCoords[i];
                }
            }
            rotation = 180;
        }
        else if (rotation == 180)
        {
            CoOrd[] flippedCoords = new CoOrd[3];
            for (int i = 0; i < flippedCoords.Length; i++)
            {
                flippedCoords[i].xCord = horizontalOffsets[i].xCord * -1;
                flippedCoords[i].yCord = horizontalOffsets[i].yCord * -1;
            }
            if (CheckIfCoordsAreFree(flippedCoords, limit, map))
            {
                for (int i = 0; i < offsets.Length; i++)
                {
                    offsets[i] = flippedCoords[i];
                }
            }
            rotation = 270;
        }
        else if (rotation == 270 && CheckIfCoordsAreFree(verticalOffsets, limit, map))
        {
            for (int i = 0; i < offsets.Length; i++)
            {
                offsets[i] = verticalOffsets[i];
            }
            rotation = 0;
        }
    }

}
