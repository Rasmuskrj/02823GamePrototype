using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;   
    public int currentHealth;
                
      
    bool damaged;
    public SurvivalShooter main;

    void Awake()
    {
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount)
    {
        SoundManager.Instance.yoDead.Play();
        currentHealth -= amount;
        
        if ( currentHealth <= 0 )
        {
            main.playerLost();   
        }
    }


    void Death()
    {
        
        //disable game somehow?
    }
}