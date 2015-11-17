using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    public GameObject enemy;               
    public Transform enemySpawn;
    public float spawnTime = 3f;            

    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    void Update()
    {

    }

    void Spawn()
    {
        
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        GameObject newEnemy;
        Rigidbody rb;
        newEnemy = Instantiate(enemy);
        rb = newEnemy.GetComponent<Rigidbody>();
        newEnemy.transform.parent = gameObject.transform;
        rb.velocity = new Vector3(5, 0, 0);
        
    }
}