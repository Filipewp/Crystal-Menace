using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLook : MonoBehaviour
{
    [SerializeField]
    //Transform _destination = null;

    //NavMeshAgent _navMeshAgent;

    public int attackDamage = 20;

    //public Vector3 attackOffset;
    // public float attackRange = 1f;
    //public LayerMask attackMask;

    //public Collider bCol;


    // Start is called before the first frame update
    void Start()
    {

        // bCol.enabled = false;
    }

    public void Attack(float amount)
    {


        gameObject.GetComponent<Target>().TakeDamage(attackDamage);

        //Vector3 pos = transform.position;
        //pos += transform.right * attackOffset.x;
        //pos += transform.up * attackOffset.y;

        //Collider colInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        //if(colInfo != null)
        //{
        //    colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        //}
    }


    //public void SetDestination()
    //{
    //    if (_destination != null)
    //    {
    //        Vector3 targetVector = _destination.transform.position;
    //        _navMeshAgent.SetDestination(targetVector);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    _navMeshAgent = this.GetComponent<NavMeshAgent>();

    //    if (_navMeshAgent == null)
    //    {
    //        Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
    //    }
    //    else
    //    {
    //        SetDestination();
    //    }
    //}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Player");
            enemy.GetComponent<Target>().TakeDamage(attackDamage);


            Debug.Log("Colidiu");
        }
    }

}
