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
        if(isPlayer == false)
        {
            setRigidBodyState(true);
            //setColliderState(true);

        }
        
      

    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
       
        if (currentHealth <= 0f)
        {
            setRigidBodyState(false);
            Die();           
          
        }
    }

    void Die()
    {
        if (isPlayer == false)
        { 
           
            Destroy(gameObject);
            //GetComponent<Animator>().enabled = false;
            //GetComponent<EnemyAI>().isDead = true;
          
           
            //setColliderState(true);
        }
        else
        {
            Debug.Log("Dead");
        }
          


    }

    void setRigidBodyState(bool Rstate)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = Rstate;
        }
        //GetComponentInParent<Rigidbody>().isKinematic = Rstate;
        //GetComponent<Rigidbody>().isKinematic = !Rstate;
    }
    //void setColliderState(bool Cstate)
    //{
    //    Collider[] colliders = GetComponentsInChildren<Collider>();

    //    foreach (Collider collider in colliders)
    //    {
    //        collider.enabled = Cstate;
    //    }
    //    GetComponentInParent<Collider>().enabled = Cstate;
    //   // GetComponent<Collider>().enabled = !Cstate;
    //}
}