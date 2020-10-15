using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agro : MonoBehaviour
{
    public NavMeshAgent Enemy;

    GameObject[] targets;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Enemy.SetDestination(other.gameObject.transform.position);
        }
    }
}


