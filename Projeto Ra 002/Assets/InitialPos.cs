using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPos : MonoBehaviour
{
    //discarded, better implemented in RespawnBrain
    public GameObject player;
    public Transform playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPos = gameObject.transform;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = playerStartPos.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
