using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;
    

    void Update()
    {
    }

    public void MoveXRaw(float axisx)
    {
        GameObject newShot;
        Rigidbody rb;
        newShot = Instantiate(shot);
        rb = newShot.GetComponent<Rigidbody>();
        newShot.transform.parent = gameObject.transform;
        newShot.transform.localPosition = new Vector3(0f, 0f, 0f);
        rb.velocity = new Vector3(axisx, 0, 0);
    }

    public void MoveYRaw(float axisy)
    {
        GameObject newShot;
        Rigidbody rb;
        newShot = Instantiate(shot);
        rb = newShot.GetComponent<Rigidbody>();
        newShot.transform.parent = gameObject.transform;
        newShot.transform.localPosition = new Vector3(0f, 0f, 0f);
        rb.velocity = new Vector3(0, axisy, 0);
    }


}