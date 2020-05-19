using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public bool on;
    private float range;

    public GameObject player;
    public GameObject[] begone;


    // Start is called before the first frame update
    void Start()
    {
        
        range = 5;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && !on)// /?
        {
            Debug.Log("Cu1");
            On();
        }
        else if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && on)// /?
        {
            Debug.Log("Cu2");
            Off();
        }
    }

    void On()
    {
        for (int i = 0; i < begone.Length; i++)
        {
            begone[i].GetComponent<Renderer>().enabled = false;
            begone[i].GetComponent<Collider>().enabled = false;
        }


        on = true;
    }

    void Off()
    {
        for (int i = 0; i < begone.Length; i++)
        {
            begone[i].GetComponent<Renderer>().enabled = true;
            begone[i].GetComponent<Collider>().enabled = true;
        }
        on = false;
    }
}

