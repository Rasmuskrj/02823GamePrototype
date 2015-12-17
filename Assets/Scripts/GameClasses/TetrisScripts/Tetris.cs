using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Tetris : GameClass {
    
    [System.Serializable]
    public struct mapVal
    {
        public bool cubeInPos;
        public bool cubeDrawn;
        public GameObject cube;
        public Color color;

        public mapVal(bool pos, bool drawn){
            cubeInPos = pos;
            cubeDrawn = drawn;
            cube = null;
            color = Color.clear;
        }
    }
    public TetrisBlock activeBlock;
    public int increaseScoreEvery = 500;
    public int mapWidth = 10;
    public int mapHeight = 60;
    public GameObject cube;
    public mapVal[,] tetris2DMap;
    public float updateTime = 0.5f;
    private bool AIplacedBlock = false;
    

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

    void Update()
    {
        if (isAI)
        {
            AIMoveBlock();
        }
    }

    private void AIMoveBlock()
    {
        if (!AIplacedBlock)
        {
            int colToGoTo = -1;
            for (int i = 0; i < tetris2DMap.GetLength(1); i++)
            {
                for (int j = 0; j < tetris2DMap.GetLength(0); j++)
                {
                    if (!tetris2DMap[j, i].cubeInPos)
                    {
                        colToGoTo = j;
                        break;
                    }
                }
                if (colToGoTo >= 0)
                {
                    break;
                }
            }
            if (activeBlock != null)
            {
                if (activeBlock.pos.xCord < colToGoTo)
                {
                    MoveBlockSideways(1);
                }
                else if (activeBlock.pos.xCord > colToGoTo)
                {
                    MoveBlockSideways(-1);
                }
                else
                {
                    AIplacedBlock = true;
                    //Do Nothing
                }
            }
        }
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
        playerLost();
        //gameObject.SetActive(true);
       
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
                    //In this pass the only cells that should be drawn are from the active block, so we use that color
                    thisCube.GetComponent<Renderer>().material.color = activeBlock.blockColor;
                    tetris2DMap[i, j].color = activeBlock.blockColor;
                    tetris2DMap[i, j].cubeDrawn = true;
                    tetris2DMap[i, j].cube = thisCube;
                }
            }
        }
    }

    override public void IncreaseDifficulty()
    {
        if(updateTime - 0.05f > 0.00001f) {//Minimum value for invokeRepeating
            CancelInvoke("UpdateGame");
            updateTime -= 0.05f;
            InvokeRepeating("UpdateGame", 0, updateTime);
            difficulty++;
            SoundManager.Instance.IncreaseMusicFrequency();
        }
    }

    override public void ReduceDifficulty()
    {
        CancelInvoke("UpdateGame");
        updateTime += 0.05f;
        InvokeRepeating("UpdateGame", 0, updateTime);
        if (difficulty == 0) { Tokens++; return; }
        difficulty--;
    }

    void moveBlock()
    {
        if (activeBlock != null)
        {
            bool willCollide = false;
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
                    ClearCell(coords[i].xCord, coords[i].yCord);
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

    private void ClearCell(int x, int y)
    {
        Destroy(tetris2DMap[x, y].cube);
        tetris2DMap[x, y].cube = null;
        tetris2DMap[x, y].cubeDrawn = false;
        tetris2DMap[x, y].cubeInPos = false;
        tetris2DMap[x, y].color = Color.clear;
    }

    public void CreateNewBlock()
    {
        Debug.Log("Spawning new tetris block");
        TetrisBlock newBlock = new TetrisBlock(isAI);
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
        AIplacedBlock = false;
    }

    override public void MoveXRaw(float axisx)
    {
        if (activeBlock != null && !isAI)
        {
            MoveBlockSideways(axisx);
        }
    }

    private void MoveBlockSideways(float axisx)
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


    override public void MoveYRaw(float axisy)
    {
        
        
    }

    override public void MoveY(float axisy)
    {
       
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
                                ClearCell(u, k);
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
                                    ClearCell(u, k);

                                }
                                else if (!tetris2DMap[u, k].cubeInPos && tetris2DMap[u, k + 1].cubeInPos)
                                {
                                    tetris2DMap[u, k].cubeInPos = true;
                                    float posX = gameObject.transform.position.x + u;
                                    float posY = gameObject.transform.position.y + k;
                                    GameObject thisCube = Instantiate(cube, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
                                    thisCube.GetComponent<Renderer>().material.color = tetris2DMap[u, k + 1].color;
                                    tetris2DMap[u, k].cubeDrawn = true;
                                    tetris2DMap[u, k].cube = thisCube;
                                    tetris2DMap[u, k].color = tetris2DMap[u, k + 1].color;
                                }
                                else if (tetris2DMap[u, k].cubeInPos && tetris2DMap[u, k + 1].cubeInPos)
                                {
                                    tetris2DMap[u, k].cube.GetComponent<Renderer>().material.color = tetris2DMap[u, k + 1].color;
                                    tetris2DMap[u, k].color = tetris2DMap[u, k + 1].color;
                                }
                            }
                        }
                    }
                    score += 5;
                    SoundManager.Instance.bingSound.Play();
                    if (score % increaseScoreEvery == 0)
                    {
                        Tokens++;
                        if (isAI) { AIUseToken(); }
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

    override public void DoOnA()
    {
        if (activeBlock != null && !isAI)
        {
            RotateBlock();
        }
    }

    private void RotateBlock()
    {
        SoundManager.Instance.blipSound.Play();
        activeBlock.RotateBlock(mapWidth, tetris2DMap);
        DestroyActiveBlock();
        activeBlock.CalculateAdditionalPos();
        drawBlock();
        drawMap();
    }

    override public void DoOnB()
    {
        if (!isAI)
        {
            MoveBlockDown();
        }
    }

    private void MoveBlockDown()
    {
        moveBlock();
        drawBlock();
        drawMap();
    }
}
