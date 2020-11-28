using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class AIRagdoll : MonoBehaviour
{
    public Rigidbody[] ragdoll;
    public int currentHealth;
    public Rigidbody body;
    public bool headVanish;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Collider arm;
  
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float attackRange;
    public bool playerInAttackRange;

  
    void Update()
    {
        //check for sight and attack range
       
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(headVanish == true)
        {
            agent.enabled = false;
            //body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        if (!playerInAttackRange && headVanish == false)
        {
            ChasePlayer();
        }
        else if(headVanish == true)
        {
            agent.enabled = false;
        }

        if (playerInAttackRange && headVanish == false)
        {
            AttackPlayer();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {

           
            foreach (Rigidbody rigidbody in ragdoll)
            {
                rigidbody.isKinematic = false;
            }
            Die();

        }
    }
    void Die()
    {
            Destroy(gameObject);           
    }
   
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            agent.speed = 30;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
          

            //Attack code here


            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        agent.speed = 4;
    }


}
