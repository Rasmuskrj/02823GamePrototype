using UnityEngine;
using System.Collections;

public class BreakoutBlockSpawner : MonoBehaviour {
    public Transform BlockPrefab;

    // Use this for initialization
    void Start()
    {
        SpawnLine();
        SpawnLine();
    }
    public void SpawnLine ()
    {
        DecentLine();
        for (int i = 0; i<30; i++)
        {
            Transform newBlock;
            newBlock = Instantiate(BlockPrefab);
            newBlock.parent = gameObject.transform;
            newBlock.localPosition = new Vector3(-14.5f + i, 10.5f);
            
            
        }
    }
    public void DecentLine()
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
