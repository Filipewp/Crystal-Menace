using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Interaction : MonoBehaviour
{
    public GameObject instructions;
    public GameObject Generator1, Generator2, Door;
    DoorController Lock;
    Flickering flick;
    public GameObject[] lightCeiling;

    void Start()
    {
        lightCeiling = GameObject.FindGameObjectsWithTag("Light");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            instructions.SetActive(true);
            Animator anim = Generator1.GetComponentInChildren<Animator>();
            Animator anim1 = Generator2.GetComponentInChildren<Animator>();
            Lock = Door.GetComponent<DoorController>();
            if (Input.GetKeyDown(KeyCode.E))
            {

                anim.SetTrigger("OnButton");
                anim1.SetTrigger("OnButton");
                Lock.Locked = false;
               
                foreach (GameObject objects in lightCeiling)
                {
                    flick = objects.GetComponent<Flickering>();
                    flick.isFlickering = true;
                    flick.stop = true;
                }
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            instructions.SetActive(false);
        }
    }
}