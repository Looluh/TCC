using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject lose;
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
            /*
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(1, 3, -95);
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            */
            lose.SetActive(true);
            Destroy(other.gameObject);

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
