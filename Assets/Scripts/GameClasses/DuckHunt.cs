﻿using UnityEngine;
using System.Collections;

public class DuckHunt : MonoBehaviour, IGameTypeInterface {
    public Camera cam;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MoveX(float axisx)
    {

    }
    public void MoveY(float axisy)
    {

    }
    public void MoveXRaw(float axisx){   }
    public void MoveYRaw(float axisy) {    }
    public void SetCamera(Rect rect)
    {
        cam.rect = rect;
    }
    public void IncreaseDifficulty()
    {

    }
}
