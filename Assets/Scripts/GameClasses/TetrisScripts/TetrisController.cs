using UnityEngine;
using System.Collections;

public class TetrisController : MonoBehaviour {

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

        activeBlock = new TetrisBlock();
        activeBlock.pos = new TetrisBlock.CoOrd(5, 20);
        activeBlock.CalculateAdditionalPos();

        CreateWalls();



        InvokeRepeating("UpdateGame",0, 0.5f);
        

	}

    private void CreateWalls()
    {
        GameObject leftWall = Instantiate(cube) as GameObject;
        leftWall.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y + mapHeight/2, 0);
        leftWall.transform.localScale += new Vector3(0, mapHeight + 2, 0);
        GameObject rightWall = Instantiate(cube) as GameObject;
        rightWall.transform.position = new Vector3(gameObject.transform.position.x + mapWidth + 1, gameObject.transform.position.y + mapHeight/2, 0);
        rightWall.transform.localScale += new Vector3(0, mapHeight + 2, 0);
        GameObject topWall = Instantiate(cube) as GameObject;
        topWall.transform.position = new Vector3(gameObject.transform.position.x + mapWidth/2, gameObject.transform.position.y + mapHeight + 1, 0);
        topWall.transform.localScale += new Vector3(mapWidth + 2, 0, 0);
        GameObject botWall = Instantiate(cube) as GameObject;
        botWall.transform.position = new Vector3(gameObject.transform.position.x + mapWidth/2, gameObject.transform.position.y - 1, 0);
        botWall.transform.localScale += new Vector3(mapWidth + 2, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void drawBlock()
    {
        TetrisBlock.CoOrd[] coords = activeBlock.GetInhabitedCoords();
        for (int i = 0; i < coords.Length; i++ )
        {
            tetris2DMap[coords[i].xCord,coords[i].yCord].cubeInPos = true;
        }
    }

    void UpdateGame()
    {
        moveBlock();
        drawBlock();
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                if (tetris2DMap[i,j].cubeInPos && !tetris2DMap[i,j].cubeDrawn)
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
        TetrisBlock.CoOrd[] coords = activeBlock.GetInhabitedCoords();
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
}
