using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShotAt : MonoBehaviour
{
    public GameObject begone;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot")
        {
            begone.GetComponent<Renderer>().enabled = false;
            begone.GetComponent<Collider>().enabled = false;
        }
    }


}

