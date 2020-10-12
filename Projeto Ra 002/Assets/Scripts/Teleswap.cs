using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Teleswap : MonoBehaviour
{
    public Transform player;
    public Transform myself;
    public Transform brain;

    public AudioSource audS;
    public AudioClip audC;
    // Start is called before the first frame update
    void Start()
    {
        brain = GameObject.FindWithTag("respawnBrain").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shot"))
        {
            brain.transform.position = player.transform.position;

            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(myself.transform.position.x, player.transform.position.y + 0.15f, myself.transform.position.z) ;
            player.GetComponent<CharacterController>().enabled = true;

            myself.transform.position = new Vector3(brain.transform.position.x, myself.transform.position.y, brain.transform.position.z);

            audS.PlayOneShot(audC);
        }
    }
}
