using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int gameScore;
    public int difficulty;
    public bool isAlive;
    // Use this for initialization
    void Start () {
        gameScore = 0;
        difficulty = 0;
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
