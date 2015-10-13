using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    public static GameManager instance { get; private set; }
    // Use this for initialization
    void Start()
    {
        player1.gameScore = 0;
        player2.gameScore = 0;
        player3.gameScore = 0;
        player4.gameScore = 0;
    }
    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {

    }
    int GetNextGame (int gameID)
    {
        return 1;
    }
}
