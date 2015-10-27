using UnityEngine;
using System.Collections;

public class TetrisController : MonoBehaviour {

    private float unitDistance = 1.0f;
    public GameObject leftWall;
    public GameObject rightWall;

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
        Vector3 pointLeft = leftWall.GetComponent<Collider>().ClosestPointOnBounds(rightWall.transform.position);
        Vector3 pointRight = rightWall.GetComponent<Collider>().ClosestPointOnBounds(leftWall.transform.position);

        float distance = Vector3.Distance(pointLeft, pointRight);
        unitDistance = distance / 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float GetUnitDistance()
    {
        return unitDistance;
    }
}
