using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool Locked = false;
    public GameObject DoorLight;
    public GameObject LockText;
    public GameObject instructions;
    public GameObject DoorGene, LockMiddle, Elevator;
    public AudioClip DoorLocked;
    public AudioSource DoorAudio;

   
    void Update()
    {
        if (Locked == true)
        {
            DoorLight.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
            
            
        }
        else
        {
           
            DoorLight.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
        }
    }
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
                DoorAudio.clip = DoorLocked;
                DoorAudio.Play();
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
