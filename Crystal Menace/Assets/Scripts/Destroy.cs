using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject doorControl;
    public AudioSource DoorSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            doorControl.GetComponent<DoorController>().Locked = true;
            doorControl.GetComponentInChildren<Animator>().SetTrigger("OpenClose");
            DoorSound.Play();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }


}
