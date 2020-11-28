using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] dialogues1;
    public AudioClip[] dialogues2;
    public AudioClip[] dialogues3;
    public AudioClip[] dialogues4;
    public AudioClip[] dialogues5;
    public GameObject[] triggers;
   
    public AudioSource adSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Trigger1")
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < dialogues1.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                adSource.clip = dialogues1[i];

                //3.Play Audio
                adSource.Play();

                //4.Wait for it to finish playing
                while (adSource.isPlaying)
                {
                    yield return null;
                }
            }
        }

        if (other.tag == "Trigger2")
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < dialogues2.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                adSource.clip = dialogues2[i];

                //3.Play Audio
                adSource.Play();

                //4.Wait for it to finish playing
                while (adSource.isPlaying)
                {
                    yield return null;
                }
            }
        }

        if (other.tag == "Trigger3")
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < dialogues3.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                adSource.clip = dialogues3[i];

                //3.Play Audio
                adSource.Play();

                //4.Wait for it to finish playing
                while (adSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
        if (other.tag == "Trigger4")
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < dialogues4.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                adSource.clip = dialogues4[i];

                //3.Play Audio
                adSource.Play();

                //4.Wait for it to finish playing
                while (adSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
        if (other.tag == "Trigger5")
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < dialogues5.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                adSource.clip = dialogues5[i];

                //3.Play Audio
                adSource.Play();

                //4.Wait for it to finish playing
                while (adSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }


    

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trigger1")
        {
            triggers[0].SetActive(false);
        }
        if (other.tag == "Trigger2")
        {
            triggers[1].SetActive(false);
        }
        if (other.tag == "Trigger3")
        {
            triggers[2].SetActive(false);
        }
        if (other.tag == "Trigger4")
        {
            triggers[3].SetActive(false);
        }
        if (other.tag == "Trigger5")
        {
            triggers[4].SetActive(false);
        }
    }

   
}
