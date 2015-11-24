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
    override public void MoveX(float axisx){  }
    override public void MoveY(float axisy) {  }
    override public void MoveXRaw(float axisx){   }
    override public void MoveYRaw(float axisy) {    }
    override public void IncreaseDifficulty()
    {
        difficulty++;
    }
    public override void ReduceDifficulty()
    {
        difficulty--;
    }
}
