using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private bool p1x_isAxisInUse = false;
    private bool p1y_isAxisInUse = false;
    private float nextFire;

    void Update()
    {
        if (Input.GetAxisRaw("P1Horizontal") != 0)
        {
            if (p1x_isAxisInUse == false)
            {
                p1x_isAxisInUse = true;
                MoveXRaw(Input.GetAxisRaw("P1Horizontal"));
            }
        }
        else
        {
            p1x_isAxisInUse = false;
        }

        if (Input.GetAxisRaw("P1Vertical") != 0)
        {
            if (p1y_isAxisInUse == false)
            {
                p1y_isAxisInUse = true;
                MoveYRaw(Input.GetAxisRaw("P1Vertical"));
            }
        }
        else
        {
            p1y_isAxisInUse = false;
        }
    }

    public void MoveXRaw(float axisx)
    {
        GameObject newShot;
        Rigidbody rb;
        newShot = Instantiate(shot);
        rb = newShot.GetComponent<Rigidbody>();
        newShot.transform.parent = gameObject.transform;
        rb.velocity = new Vector3(axisx, 0, 0);
    }

    public void MoveYRaw(float axisy)
    {
        GameObject newShot;
        Rigidbody rb;
        newShot = Instantiate(shot);
        rb = newShot.GetComponent<Rigidbody>();
        newShot.transform.parent = gameObject.transform;
        rb.velocity = new Vector3(0, axisy, 0);
    }


}