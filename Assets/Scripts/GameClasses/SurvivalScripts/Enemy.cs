using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public PlayerHealth playerHealth;

    void Update () {
	
        if(transform.localPosition.magnitude < 1.5)
        {
            playerHealth.currentHealth--;
            Destroy(gameObject);
        }

	}
}
