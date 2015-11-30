using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity *= speed;
    }

    void Update()
    {
        /*if (Mathf.Abs(transform.localPosition.x) > 30f)
        {
            Destroy(gameObject);
        }

        if (Mathf.Abs(transform.localPosition.y) > 30f)
        {
            Destroy(gameObject);
        }*/
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.name);
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

}
