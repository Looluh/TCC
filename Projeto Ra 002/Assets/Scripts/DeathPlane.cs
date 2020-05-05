using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
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
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(0, 1.5f, 13);
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
