using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtButtonOn : MonoBehaviour
{
    //começa desligado e aí liga

    public GameObject[] begone;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot")
        {
            for (int i = 0; i < begone.Length; i++)
            {
                begone[i].GetComponent<Renderer>().enabled = true;
                begone[i].GetComponent<Collider>().enabled = true;
            }
        }
    }


}

