using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool Locked = false;
    public GameObject LockText;
    public GameObject instructions;
    public GameObject DoorGene, LockMiddle, Elevator;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            instructions.SetActive(true);
            Animator anim = GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E) && (Locked == false))
            {
                anim.SetTrigger("OpenClose");

            }
            else if(Input.GetKeyDown(KeyCode.E) && (Locked == true))
            {
                LockText.SetActive(true);
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            instructions.SetActive(false);
            LockText.SetActive(false);
        }
       
    }
}
