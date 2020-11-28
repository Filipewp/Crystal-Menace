using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnShoot : MonoBehaviour
{
    public Rigidbody[] ragdoll;

    public int currentHealth;

    public GameObject parent;
    public GameObject partToVanish;
    private Animator _animator;
    public GameObject replacement;
    public GameObject headPart;
    public GameObject Mainbody;
    public GameObject bodyToVanish;
    public AIRagdoll headGone;
    
    //public Canvas canv;

    public float health = 50f;

    public void Start()
    {
        _animator = parent.GetComponent<Animator>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            return;
        }

        _animator.enabled = false;
        Destroy(partToVanish);
    }

    public void Vanish(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            // canv.enabled = false;
            
            _animator.enabled = false;
            GameObject clone = GameObject.Instantiate(replacement, parent.transform.position, parent.transform.rotation);
            Destroy(partToVanish);
            //GameObject cloneBody = GameObject.Instantiate(Mainbody, parent.transform.position, parent.transform.rotation);
            //Destroy(bodyToVanish);
           // Dead.isStopped = true;
            Destroy(parent, 10.0f);
            Destroy(clone, 10.0f);
           //Destroy(cloneBody, 10.0f);
            headGone.headVanish = true;
            
            foreach (Rigidbody rigidbody in ragdoll)
            {
                rigidbody.isKinematic = false;
            }
           
        }

    }
    
}
