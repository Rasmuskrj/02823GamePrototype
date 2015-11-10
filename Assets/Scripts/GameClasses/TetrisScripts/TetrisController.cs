﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TetrisController : MonoBehaviour, IGameTypeInterface {

    public struct mapVal
    {
        public bool cubeInPos;
        public bool cubeDrawn;
        public GameObject cube;

        public mapVal(bool pos, bool drawn){
            cubeInPos = pos;
            cubeDrawn = drawn;
            cube = null;
        }
    }

    public TetrisBlock activeBlock;
    public int mapWidth = 10;
    public int mapHeight = 60;
    public GameObject cube;
    private mapVal[,] tetris2DMap;


    public static TetrisController Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        Instance = this;
        
    }

	// Use this for initialization
	void Start () {
        tetris2DMap = new mapVal[mapWidth, mapHeight];
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                tetris2DMap[i, j] = new mapVal(false, false);
            }
        }

        CreateWalls();



        InvokeRepeating("UpdateGame",0, 0.5f);
        

	}

    private void CreateWalls()
    {
        GameObject leftWall = Instantiate(cube) as GameObject;
        leftWall.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + mapHeight/2, 0);
        leftWall.transform.localScale += new Vector3(0, mapHeight + 2, 0);
        GameObject rightWall = Instantiate(cube) as GameObject;
        rightWall.transform.position = new Vector3(gameObject.transform.position.x + mapWidth, gameObject.transform.position.y + mapHeight/2, 0);
        rightWall.transform.localScale += new Vector3(0, mapHeight + 2, 0);
        GameObject topWall = Instantiate(cube) as GameObject;
        topWall.transform.position = new Vector3(gameObject.transform.position.x + mapWidth/2, gameObject.transform.position.y + mapHeight + 1, 0);
        topWall.transform.localScale += new Vector3(mapWidth, 0, 0);
        GameObject botWall = Instantiate(cube) as GameObject;
        botWall.transform.position = new Vector3(gameObject.transform.position.x + mapWidth/2, gameObject.transform.position.y - 1, 0);
        botWall.transform.localScale += new Vector3(mapWidth, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            MoveX(Input.GetAxis("Horizontal"));
            //p1Games[currentP1Game].MoveX(Input.GetAxis("Horrizontal")); //for later use
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            MoveY(Input.GetAxis("Vertical"));
            //p1Games[currentP1Game].MoveY(Input.GetAxis("Vertical")); // for later use
        }
	}

    void drawBlock()
    {
        if (activeBlock != null)
        {
            TetrisBlock.CoOrd[] coords = activeBlock.GetInhabitedCoords();
            for (int i = 0; i < coords.Length; i++)
            {
                tetris2DMap[coords[i].xCord, coords[i].yCord].cubeInPos = true;
            }
        }
    }

    void UpdateGame()
    {
        if (activeBlock == null)
        {
            CreateNewBlock();
        }
        moveBlock();
        drawBlock();
        drawMap();
    }

    private void drawMap()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                if (tetris2DMap[i, j].cubeInPos && !tetris2DMap[i, j].cubeDrawn)
                {
                    float posX = gameObject.transform.position.x + i;
                    float posY = gameObject.transform.position.y + j;
                    GameObject thisCube = Instantiate(cube, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
                    tetris2DMap[i, j].cubeDrawn = true;
                    tetris2DMap[i, j].cube = thisCube;
                }
            }
        }
    }

    void moveBlock()
    {
        bool willCollide = false;
        List<TetrisBlock.CoOrd> lowestCoOrds = activeBlock.GetLowestYCoOrds();
        TetrisBlock.CoOrd[] coords = activeBlock.GetInhabitedCoords();

        for (int i = 0; i < coords.Length; i++)
        {
            if (coords[i].yCord <= 0 || (tetris2DMap[coords[i].xCord, coords[i].yCord - 1].cubeInPos && !activeBlock.CheckIfCoOrdInBlock(new TetrisBlock.CoOrd(coords[i].xCord, coords[i].yCord - 1))))
            {
                willCollide = true;
            }
        }

        /*for (int i = 0; i < lowestCoOrds.Count; i++)
        {
            if (lowestCoOrds[i].yCord <= 0 || tetris2DMap[lowestCoOrds[i].xCord, lowestCoOrds[i].yCord - 1].cubeInPos)
            {
                willCollide = true;
            }
        }*/
        if (!willCollide) {
            for (int i = 0; i < coords.Length; i++)
            {
                Destroy(tetris2DMap[coords[i].xCord, coords[i].yCord].cube);
                tetris2DMap[coords[i].xCord, coords[i].yCord].cube = null;
                tetris2DMap[coords[i].xCord, coords[i].yCord].cubeDrawn = false;
                tetris2DMap[coords[i].xCord, coords[i].yCord].cubeInPos = false;
            }
            activeBlock.pos.yCord--;
            activeBlock.CalculateAdditionalPos();
        }
        else
        {
            activeBlock = null;
        }
    }

    public void CreateNewBlock()
    {
        activeBlock = new TetrisBlock();
        activeBlock.pos = new TetrisBlock.CoOrd(5, 20);
        activeBlock.CalculateAdditionalPos();
    }

    public void MoveX(float axisx)
    {
        if (activeBlock != null)
        {
            int offset = axisx < 0 ? -1 : 1;
            bool limitCheck = false;
            if (offset == -1)
            {
                limitCheck = activeBlock.CheckOutOfBounds(0, true);
            }
            else
            {
                limitCheck = activeBlock.CheckOutOfBounds(mapWidth, false);
            }
            if (limitCheck)
            {
                TetrisBlock.CoOrd[] coords = activeBlock.GetInhabitedCoords();
                for (int i = 0; i < coords.Length; i++)
                {
                    Destroy(tetris2DMap[coords[i].xCord, coords[i].yCord].cube);
                    tetris2DMap[coords[i].xCord, coords[i].yCord].cube = null;
                    tetris2DMap[coords[i].xCord, coords[i].yCord].cubeDrawn = false;
                    tetris2DMap[coords[i].xCord, coords[i].yCord].cubeInPos = false;
                }
                activeBlock.pos = new TetrisBlock.CoOrd(activeBlock.pos.xCord + offset, activeBlock.pos.yCord);
                activeBlock.CalculateAdditionalPos();
                drawBlock();
                drawMap();
            }
        }
    }

    public void MoveY(float axisy)
    {
        
    }
}
