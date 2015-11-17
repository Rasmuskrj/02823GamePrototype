﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject enemy;
    public Transform[] enemySpawn;
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public float speed = 0.5f;
    private int ran;
   
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    void Update()
    {

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
    }
}
