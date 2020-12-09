using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
   
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
            GameObject clone1 = GameObject.Instantiate(enemyToSpawn, spawn1.transform.position, spawn1.transform.rotation);
            GameObject clone2 = GameObject.Instantiate(enemyToSpawn, spawn2.transform.position, spawn2.transform.rotation);
            GameObject clone3 = GameObject.Instantiate(enemyToSpawn, spawn3.transform.position, spawn3.transform.rotation);

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
