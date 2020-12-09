using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnShoot : MonoBehaviour
{
    //bomb effect

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    Collider coll;
    public AudioSource crystalSound;
    public Rigidbody[] ragdoll;

    public int currentHealth;

    public GameObject parent;
    public GameObject positionHead;
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
        coll = GetComponent<Collider>();
    }

   

    public void Vanish(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            // canv.enabled = false;
            
            //_animator.enabled = false;
            GameObject clone = GameObject.Instantiate(replacement, positionHead.transform.position, positionHead.transform.rotation);
            Destroy(partToVanish);
            Detonate();
            coll.enabled = false;
            //GameObject cloneBody = GameObject.Instantiate(Mainbody, parent.transform.position, parent.transform.rotation);
            //Destroy(bodyToVanish);
            // Dead.isStopped = true;
            headGone.headVanish = true;
            //Destroy(parent, 10.0f);
            Destroy(clone, 10.0f);
            crystalSound.Play();
           //Destroy(cloneBody, 10.0f);
           
            
            //foreach (Rigidbody rigidbody in ragdoll)
            //{
            //    rigidbody.isKinematic = false;
            //}
           
        }

    }
    void Detonate()
    {
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }

}
