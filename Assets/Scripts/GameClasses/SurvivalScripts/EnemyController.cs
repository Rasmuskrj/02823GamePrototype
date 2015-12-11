using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject enemy;
    public Transform[] enemySpawn;
    public PlayerHealth playerHealth;
    public SurvivalShooter shooter;
    private float speed = 0.8f;
    private int ran;
    public float resettime = 0.5f;
    public float nextspawn = 0f;
    public bool isAI;
    void Start()
    {
        //InvokeRepeating("Spawn", 0, spawnTime);
    }

    void FixedUpdate()
    {
        if (Time.time > nextspawn)
        {

            nextspawn = Time.time + resettime;
            Spawn();
        }
    }

    void Spawn()
    {
        ran = Random.Range(0, 4); 

        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }


        GameObject newEnemy;
        Rigidbody rb;
        newEnemy = Instantiate(enemy);
        rb = newEnemy.GetComponent<Rigidbody>();
        newEnemy.transform.parent = gameObject.transform;
        newEnemy.transform.position = enemySpawn[ran].position;
        rb.velocity = -newEnemy.transform.localPosition * speed;
        newEnemy.GetComponent<Enemy>().playerHealth = playerHealth;
        if (isAI)
        {
            if (rb.velocity.x != 0)
            {
                shooter.MoveXRaw(-rb.velocity.x);
            }
            else {
                shooter.MoveYRaw(-rb.velocity.y);
            }
        }
    }
}
