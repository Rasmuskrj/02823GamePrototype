using UnityEngine;
using System.Collections;

public class BreakoutBlockSpawner : MonoBehaviour {
    public Transform BlockPrefab;

    // Use this for initialization
    void Start()
    {
        SpawnLine();
    }
    void SpawnLine ()
    {
        DecentLine();
        for (int i = 0; i<10; i++)
        {
            Transform newBlock;
            newBlock = Instantiate(BlockPrefab);
            newBlock.position = new Vector3(-4.5f + i, 10.5f);
            newBlock.parent = gameObject.transform;
        }
    }
    void DecentLine()
    {
        foreach (Transform child in transform)
        {
            child.transform.position = new Vector3 (child.transform.position.x,child.transform.position.y-1f);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
