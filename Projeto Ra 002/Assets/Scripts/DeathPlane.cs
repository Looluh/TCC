using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject player;
    public PlayerController playCon;
    // Start is called before the first frame update
    void Start()
    {
        //playCon = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playCon.currentState = PlayerController.PlayerState.Dead;
            /*
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(1, 3, -95);
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            */
            //lose.SetActive(true);
            //Destroy(other.gameObject);

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
