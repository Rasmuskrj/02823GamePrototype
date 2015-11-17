using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;   
    public int currentHealth;
                
    bool isDead;   
    bool damaged;         


    void Awake()
    {
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            
        }
    }


    void Death()
    {
        isDead = true;
        //disable game somehow?
    }
}