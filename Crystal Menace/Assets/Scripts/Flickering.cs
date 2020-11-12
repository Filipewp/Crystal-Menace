﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public bool isFlickering = false;
    public bool stop = false;
    public float timeDelay;
    void Update()
    {
        if (isFlickering == false && stop == false)
        {
            StartCoroutine(FlickeringLight());
        }

    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.3f, 1.0f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}

