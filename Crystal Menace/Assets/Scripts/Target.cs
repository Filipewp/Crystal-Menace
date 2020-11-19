using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

   
    public Material hpModule1;
    public Material hpModule2;
    public Material hpModule3;
    public Material hpModule4;
    public Material hpModule5;
    public Material hpModule6;
    public Material hpModule7;
    public Material hpModule8;
    public Material hpModule9;
    public Material hpModule10;

    public bool isPlayer = false;


    void Start()
    {
        
        currentHealth = maxHealth;
       
        if (isPlayer == false)
        {
            setRigidBodyState(true);
            //setColliderState(true);

        }
       


    }

    void Update()
    {
        if (currentHealth == 100f)
        {
           
            hpModule1.SetColor("_BaseColor", Color.red);
            hpModule2.SetColor("_BaseColor", Color.red);
            hpModule3.SetColor("_BaseColor", Color.red);
            hpModule4.SetColor("_BaseColor", Color.red);
            hpModule5.SetColor("_BaseColor", Color.red);
            hpModule6.SetColor("_BaseColor", Color.red);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);

        }
        if (currentHealth == 90f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.red);
            hpModule3.SetColor("_BaseColor", Color.red);
            hpModule4.SetColor("_BaseColor", Color.red);
            hpModule5.SetColor("_BaseColor", Color.red);
            hpModule6.SetColor("_BaseColor", Color.red);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);

        }
        if (currentHealth == 80f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.red);
            hpModule4.SetColor("_BaseColor", Color.red);
            hpModule5.SetColor("_BaseColor", Color.red);
            hpModule6.SetColor("_BaseColor", Color.red);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 70f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.red);
            hpModule5.SetColor("_BaseColor", Color.red);
            hpModule6.SetColor("_BaseColor", Color.red);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 60f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.red);
            hpModule6.SetColor("_BaseColor", Color.red);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 50f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.black);
            hpModule6.SetColor("_BaseColor", Color.red);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 40f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.black);
            hpModule6.SetColor("_BaseColor", Color.black);
            hpModule7.SetColor("_BaseColor", Color.red);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 30f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.black);
            hpModule6.SetColor("_BaseColor", Color.black);
            hpModule7.SetColor("_BaseColor", Color.black);
            hpModule8.SetColor("_BaseColor", Color.red);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 20f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.black);
            hpModule6.SetColor("_BaseColor", Color.black);
            hpModule7.SetColor("_BaseColor", Color.black);
            hpModule8.SetColor("_BaseColor", Color.black);
            hpModule9.SetColor("_BaseColor", Color.red);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth == 10f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.black);
            hpModule6.SetColor("_BaseColor", Color.black);
            hpModule7.SetColor("_BaseColor", Color.black);
            hpModule8.SetColor("_BaseColor", Color.black);
            hpModule9.SetColor("_BaseColor", Color.black);
            hpModule10.SetColor("_BaseColor", Color.red);
        }
        if (currentHealth <= 0f)
        {
            hpModule1.SetColor("_BaseColor", Color.black);
            hpModule2.SetColor("_BaseColor", Color.black);
            hpModule3.SetColor("_BaseColor", Color.black);
            hpModule4.SetColor("_BaseColor", Color.black);
            hpModule5.SetColor("_BaseColor", Color.black);
            hpModule6.SetColor("_BaseColor", Color.black);
            hpModule7.SetColor("_BaseColor", Color.black);
            hpModule8.SetColor("_BaseColor", Color.black);
            hpModule9.SetColor("_BaseColor", Color.black);
            hpModule10.SetColor("_BaseColor", Color.black);
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
       
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