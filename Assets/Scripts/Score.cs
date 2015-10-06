using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int blocksSmashed = 0;
	public static int livesLost = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		GUI.Label(new Rect(0,10,Screen.width,100), ""+ blocksSmashed + "|"+livesLost);
	}
}
