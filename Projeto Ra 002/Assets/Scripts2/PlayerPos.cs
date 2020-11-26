using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private RespawnBrain rB;
    public GameObject player;
    public CharacterController cC;
    // Start is called before the first frame update
    void Start()//Places player in the last checkpoint
    {
        rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();
        cC.enabled = false;
        player.transform.position = rB.lastCheckpointPos;
        cC.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
