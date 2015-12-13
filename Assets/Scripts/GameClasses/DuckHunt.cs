using UnityEngine;
using System.Collections;
using System;

public class DuckHunt : GameClass
{
    
    
    // Use this for initialization
    void Start () {
	
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
