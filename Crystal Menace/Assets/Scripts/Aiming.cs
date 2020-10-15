using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform chest;
    public Transform Cam;


    void Update()
    {
        chest.rotation = Cam.rotation;
    }
}
