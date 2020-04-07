using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public bool on;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag=="Player" && Input.GetKeyDown("fire1"))
        {
            Debug.Log("apertado");
            on = true;
            door.GetComponent<Renderer>().enabled = false;
            door.GetComponent<Collider>().enabled = false;
        }

      // if (Input.GetKeyDown("q"))
      // {
      //     Debug.Log("Apertado");
      //     on = false;
      //     door.GetComponent<Renderer>().enabled = true;
      //     door.GetComponent<Collider>().enabled = true;
      // }
    }


}

