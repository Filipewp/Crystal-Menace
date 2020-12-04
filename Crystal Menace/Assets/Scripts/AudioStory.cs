using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStory : MonoBehaviour
{
    public AudioClip[] dialogueEnemy;
    public AudioSource audioSource;
    public bool shootHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(shootHit == true)
        //{
        //    OnShoot();
        //}
    }

    IEnumerator OnShooty()
    {
        if (shootHit == true)
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < dialogueEnemy.Length; i++)
            {
                //2.Assign current AudioClip to audiosource
                audioSource.clip = dialogueEnemy[i];

                //3.Play Audio
                audioSource.Play();

                //4.Wait for it to finish playing
                while (audioSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }

   
}
