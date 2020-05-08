using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleswap : MonoBehaviour
{
    public Transform player;
    public Transform myself;
    public Transform brain;

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
            brain.transform.position = player.transform.position ;

            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = myself.transform.position;
            player.GetComponent<CharacterController>().enabled = true;

            myself.transform.position = brain.transform.position;
            //Destroy(gameObject);
        }
    }
}
