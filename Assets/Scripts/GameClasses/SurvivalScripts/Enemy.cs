using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public PlayerHealth playerHealth;

    void Update () {
	
        if(transform.localPosition.magnitude < 1.5f)
        {
            playerHealth.TakeDamage(1);
            Destroy(gameObject);
        }
        if (transform.localPosition.magnitude > 20f) { Destroy(gameObject); }
    }
}
