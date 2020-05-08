using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleshot : MonoBehaviour
{
    public Transform player;
    public Transform myself;

    // Start is called before the first frame update
    void Start()
    {
        //ainda não funciona. n faço a minima ideia do pq.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shot"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = myself.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            //Destroy(gameObject);
        }
    }
}
