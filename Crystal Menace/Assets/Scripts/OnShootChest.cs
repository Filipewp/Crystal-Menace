using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShootChest : MonoBehaviour
{
    //bomb effect

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    Collider coll;

    //public Rigidbody[] ragdoll;

    public int currentHealth;

    public GameObject parent;
    public GameObject partToVanish;
    private Animator _animator;
    public GameObject replacement;
    public GameObject head;
    public GameObject hip;
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;
    public GameObject headPart;    
    public GameObject Mainbody;
    public GameObject bodyToVanish;
    public AIRagdoll chestGone;
    public AudioSource crystalSound;
    public AudioSource deathSound;
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
            GameObject clone = GameObject.Instantiate(replacement, parent.transform.position, parent.transform.rotation);
            Destroy(partToVanish);
            Detonate();
            coll.enabled = false;
            GameObject clone1 = GameObject.Instantiate(head, parent.transform.position, parent.transform.rotation);
            GameObject clone2 = GameObject.Instantiate(hip, parent.transform.position, parent.transform.rotation);
            GameObject clone3 = GameObject.Instantiate(rightArm, parent.transform.position, parent.transform.rotation);
            GameObject clone4 = GameObject.Instantiate(leftArm, parent.transform.position, parent.transform.rotation);
            GameObject clone5 = GameObject.Instantiate(rightLeg, parent.transform.position, parent.transform.rotation);
            GameObject clone6 = GameObject.Instantiate(leftLeg, parent.transform.position, parent.transform.rotation);
            chestGone.chestVanish = true;
            //Destroy(parent, 10.0f);
           
            Destroy(clone, 10.0f);
            Destroy(clone1, 10.0f);
            Destroy(clone2, 10.0f);
            Destroy(clone3, 10.0f);
            Destroy(clone4, 10.0f);
            Destroy(clone5, 10.0f);
            Destroy(clone6, 10.0f);
            crystalSound.Play();
            deathSound.Play();
            Destroy(bodyToVanish);
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
