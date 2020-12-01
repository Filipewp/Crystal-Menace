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
    public bool chestVanish;
    public bool hipVanish;
    public bool leftArmVanish;
    public bool rightArmVanish;
    public bool leftLegVanish;
    public bool rightLegVanish;

    public float coolDown = 4;
    public float coolDownTimer;

    public GameObject parent;
    public GameObject bodyToVanish;
    public GameObject NoheadNoLeftArm;
    public GameObject NoheadNoRightArm;
    public GameObject NoheadNoLeftLeg;
    public GameObject NoheadNoRightLeg;
    public GameObject NoLegs;
    public GameObject NoArms;
    public GameObject NoRightArmNoRightLeg;
    public GameObject NoRightArmNoLeftLeg;
    public GameObject NoLeftArmNoLeftLeg;

    public NavMeshAgent agent;
    //public Transform player;
    GameObject player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Collider arm;
  
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float attackRange;
    public float jumpAttackRange;
    public bool playerInAttackRange;
    public bool JumpAttack;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        

    }
    void Update()
    {
        //check for sight and attack range
       
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        JumpAttack = Physics.CheckSphere(transform.position, jumpAttackRange, whatIsPlayer);

        if(coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if(coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (!playerInAttackRange )
        {
            ChasePlayer();
        }
        

        if (playerInAttackRange )
        {
            AttackPlayer();
        }

        if (JumpAttack && coolDownTimer == 0)
        {
            JumpAttackPlayer();
        }

        if (headVanish == true && leftArmVanish == true) 
        {
            GameObject cloneBody = GameObject.Instantiate(NoheadNoLeftArm, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (headVanish == true && rightArmVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoheadNoRightArm, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (headVanish == true && leftLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoheadNoLeftLeg, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (headVanish == true && rightLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoheadNoRightLeg, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (rightArmVanish == true && leftArmVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoArms, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (rightArmVanish == true && rightLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoRightArmNoRightLeg, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (rightArmVanish == true && leftLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoRightArmNoLeftLeg, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (leftArmVanish == true && leftLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoLeftArmNoLeftLeg, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (leftArmVanish == true && rightLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoLeftArmNoLeftLeg, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }
        if (leftLegVanish == true && rightLegVanish == true)
        {
            GameObject cloneBody = GameObject.Instantiate(NoLegs, parent.transform.position, parent.transform.rotation);
            Destroy(bodyToVanish);
            Destroy(cloneBody, 10.0f);
        }

    }

    //public void TakeDamage(int amount)
    //{
    //    currentHealth -= amount;

    //    if (currentHealth <= 0f)
    //    {

           
    //        foreach (Rigidbody rigidbody in ragdoll)
    //        {
    //            rigidbody.isKinematic = false;
    //        }
    //        Die();

    //    }
    //}
    //void Die()
    //{
    //        Destroy(gameObject);           
    //}
   
    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player.transform);

        if (!alreadyAttacked)
        {
            //agent.speed = 30;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
          

            //Attack code here


            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void JumpAttackPlayer()
    {
        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);

        transform.LookAt(player.transform);

        if (!alreadyAttacked)
        {
            agent.speed = 30;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);


            //Attack code here


            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        agent.speed = 4;
    }


}
