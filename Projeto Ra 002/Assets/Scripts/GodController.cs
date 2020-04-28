using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour
{
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
        gameObject.GetComponent<SpawnEnemy>().enabled = true;
        gameObject.GetComponent<SpawnEnemy1>().enabled = true;
        gameObject.GetComponent<SpawnEnemy2>().enabled = true;
        gameObject.GetComponent<SpawnEnemy3>().enabled = true;

    }
}
