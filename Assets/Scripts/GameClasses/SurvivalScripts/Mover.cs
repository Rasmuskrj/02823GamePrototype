using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public SurvivalShooter shooter;
    public float speed;
    private Rigidbody rb;
    public int worth = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity *= speed;
    }

    void Update()
    {
        if (Mathf.Abs(transform.localPosition.x) > 30f)
        {
            Destroy(gameObject);
        }
        else if (Mathf.Abs(transform.localPosition.y) > 30f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.name);
        shooter.score += worth;
        shooter.DoOnDestroyedBlock();
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

}
