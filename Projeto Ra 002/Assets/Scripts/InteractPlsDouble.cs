using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlsDouble : MonoBehaviour
{
    private bool on;
    public float range;

    public GameObject player;
    public GameObject begone;
    public GameObject begone2;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
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
        begone.GetComponent<Renderer>().enabled = false;
        begone.GetComponent<Collider>().enabled = false;
        begone2.GetComponent<Renderer>().enabled = false;
        begone2.GetComponent<Collider>().enabled = false;


        on = true;
    }

    void Off()
    {
        begone.GetComponent<Renderer>().enabled = true;
        begone.GetComponent<Collider>().enabled = true;
        begone2.GetComponent<Renderer>().enabled = true;
        begone2.GetComponent<Collider>().enabled = true;
        on = false;
    }
}

