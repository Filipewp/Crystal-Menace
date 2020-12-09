using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint3 : MonoBehaviour
{
    public bool check3 = false;
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
            check3 = true;
        }
    }
}
