using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleAttack : MonoBehaviour
{
    public int attackDamage = 5;
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
