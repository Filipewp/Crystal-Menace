using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour
{
    public float speed = 13.5f;
    public float attackRange = 3f;
    // int damage = 20;
    Transform player;
    Rigidbody rb;
    EnemyLook enemyLook;
    public BoxCollider hitBox;
    //Target targetE;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Player");
        //if (enemy != null)
        //{

        //        enemy.GetComponent<Target>().TakeDamage(damage);


        //}
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();
        enemyLook = animator.GetComponent<EnemyLook>();

        //targetE = animator.GetComponent<Target>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        //  enemyLook.SetDestination();
        //targetE.TakeDamage(damage);

        Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}