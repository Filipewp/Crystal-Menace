using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
  
    public bool isPlayer = false;


    void Start()
    {
        currentHealth = maxHealth;
       
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
       
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (isPlayer == false)
        {
            Destroy(gameObject);
        }
       

    }
}