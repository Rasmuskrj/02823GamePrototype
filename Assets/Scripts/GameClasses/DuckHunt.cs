using UnityEngine;
using System.Collections;
using System;

public class DuckHunt : GameClass
{
    
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    override public void IncreaseDifficulty()
    {
        difficulty++;
    }
    public override void ReduceDifficulty()
    {
        difficulty--;
    }
}
