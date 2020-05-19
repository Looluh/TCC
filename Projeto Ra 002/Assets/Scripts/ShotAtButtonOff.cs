using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtButtonOff : MonoBehaviour
{
    //começa ligado e aí desliga

    public GameObject[] begone;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot")
        {
            for (int i = 0; i < begone.Length; i++)
            {
                begone[i].GetComponent<Renderer>().enabled = false;
                begone[i].GetComponent<Collider>().enabled = false;
            }
        }
    }


}

