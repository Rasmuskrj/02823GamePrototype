using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TetrisController : MonoBehaviour, IGameTypeInterface {
    
    [System.Serializable]
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
    public Camera cam;
    public TetrisBlock activeBlock;
    public float score = 0;
    public int mapWidth = 10;
    public int mapHeight = 60;
    public GameObject cube;
    public mapVal[,] tetris2DMap;
    public float updateTime = 0.5f;
    public uint gameID;
    public GameController gameController;
    

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



        InvokeRepeating("UpdateGame", 0, updateTime);
        

	}
    
    public void SetGameID(uint ID)
    {
        gameID = ID;
    }
    private void CreateWalls()
    {
        GameObject leftWall = Instantiate(cube) as GameObject;
        leftWall.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y + mapHeight/2, 0);
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
	}
    public void SetGameController(GameController gameCtrl)
    {
        gameController = gameCtrl;
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

    public void GameOver()
    {
        CancelInvoke("UpdateGame");
        gameObject.SetActive(false);
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
        if (activeBlock != null)
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

            if (!willCollide)
            {
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
                Debug.Log("active block set to null");
                while (checkCompletedLines()) ;
                activeBlock = null;
            }
        }
    }

    public void CreateNewBlock()
    {
        Debug.Log("Spawning new tetris block");
        TetrisBlock newBlock = new TetrisBlock();
        newBlock.pos = new TetrisBlock.CoOrd(5, 20);
        newBlock.CalculateAdditionalPos();
        TetrisBlock.CoOrd[] coords = newBlock.GetInhabitedCoords();
        for (int i = 0; i < coords.Length; i++)
        {
            if (tetris2DMap[coords[i].xCord, coords[i].yCord].cubeInPos)
            {
                GameOver();
                return;
            }
        }
        activeBlock = newBlock;
    }

    public void MoveXRaw(float axisx)
    {
        if (activeBlock != null)
        {
            int offset = axisx < 0 ? -1 : 1;
            bool limitCheck = false;
            if (offset == -1)
            {
                limitCheck = activeBlock.CheckOutOfBounds(0, true, tetris2DMap);
            }
            else
            {
                limitCheck = activeBlock.CheckOutOfBounds(mapWidth, false, tetris2DMap);
            }
            if (limitCheck)
            {
                DestroyActiveBlock();
                activeBlock.pos = new TetrisBlock.CoOrd(activeBlock.pos.xCord + offset, activeBlock.pos.yCord);
                activeBlock.CalculateAdditionalPos();
                drawBlock();
                drawMap();
            }
        }
    }

    public void MoveX(float axisx)
    {

    }

    public void MoveYRaw(float axisy)
    {
        int offset = axisy < 0 ? -1 : 1;
        if (offset == 1)
        {
            activeBlock.RotateBlock(mapWidth, tetris2DMap);
            DestroyActiveBlock();
            activeBlock.CalculateAdditionalPos();
            drawBlock();
            drawMap();
        }
    }

    public void MoveY(float axisy)
    {
        int offset = axisy < 0 ? -1 : 1;
        if (offset == -1)
        {
            moveBlock();
            drawBlock();
            drawMap();
        }
    }

    public bool checkCompletedLines()
    {
        for (int i = 0; i < tetris2DMap.GetLength(1); i++)
        {
            for (int j = 0; j < tetris2DMap.GetLength(0); j++)
            {
                if (!tetris2DMap[j, i].cubeInPos)
                {
                    //Debug.Log("Broke at " + j + "," + i);
                    break;
                }
                else if (j == tetris2DMap.GetLength(0) - 1)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        for (int u = 0; u < tetris2DMap.GetLength(0); u++)
                        {
                            if (k == i)
                            {
                                Destroy(tetris2DMap[u, k].cube);
                                tetris2DMap[u, k].cube = null;
                                tetris2DMap[u, k].cubeInPos = false;
                                tetris2DMap[u, k].cubeDrawn = false;
                            }
                        }
                    }
                    for (int k = 0; k < tetris2DMap.GetLength(1); k++)
                    {
                        for (int u = 0; u < tetris2DMap.GetLength(0); u++)
                        {
                            if (k >= i)
                            {
                                if (k == tetris2DMap.GetLength(1) - 1 || tetris2DMap[u, k].cubeInPos && !tetris2DMap[u, k + 1].cubeInPos)
                                {
                                    Destroy(tetris2DMap[u, k].cube);
                                    tetris2DMap[u, k].cube = null;
                                    tetris2DMap[u, k].cubeInPos = false;
                                    tetris2DMap[u, k].cubeDrawn = false;
                                }
                                else if (!tetris2DMap[u, k].cubeInPos && tetris2DMap[u, k + 1].cubeInPos)
                                {
                                    tetris2DMap[u, k].cubeInPos = true;
                                    float posX = gameObject.transform.position.x + u;
                                    float posY = gameObject.transform.position.y + k;
                                    GameObject thisCube = Instantiate(cube, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
                                    tetris2DMap[u, k].cubeDrawn = true;
                                    tetris2DMap[u, k].cube = thisCube;
                                }
                            }
                        }
                    }
                    score += 100;
                    if (score % 500 == 0)
                    {
                        Debug.Log("Tetris is increasing difficulty for other");
                        IncreaseDifficultyOnOther();
                    } 
                    return true;
                }
            }
        }
        /*string debugString = "";
        for (int i = 0; i < tetris2DMap.GetLength(1); i++)
        {
            for (int j = 0; j < tetris2DMap.GetLength(0); j++)
            {
                if (tetris2DMap[j, i].cubeInPos)
                {
                    debugString += "1 ";
                } else {
                    debugString += "0 ";
                }
            }
            debugString += "\n";
        }
        Debug.Log(debugString);*/
        return false;
    }

    private void DestroyActiveBlock()
    {
        TetrisBlock.CoOrd[] coords = activeBlock.GetInhabitedCoords();
        for (int i = 0; i < coords.Length; i++)
        {
            Destroy(tetris2DMap[coords[i].xCord, coords[i].yCord].cube);
            tetris2DMap[coords[i].xCord, coords[i].yCord].cube = null;
            tetris2DMap[coords[i].xCord, coords[i].yCord].cubeDrawn = false;
            tetris2DMap[coords[i].xCord, coords[i].yCord].cubeInPos = false;
        }
    }

    public void SetCamera(Rect rect)
    {
        cam.rect = rect;
    }

    public void IncreaseDifficulty()
    {
        CancelInvoke("UpdateGame");
        updateTime += 0.1f;
        InvokeRepeating("UpdateGame", 0, updateTime);
    }
    public void IncreaseDifficultyOnOther()
    {
        gameController.IncreaseDifficulty(gameID);
    }
}
