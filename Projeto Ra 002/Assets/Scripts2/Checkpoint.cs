using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject textpoint;

    private RespawnBrain rB;
    public PlayerController playCon;
    public float checkpointHeal;

    public KeyMaster keyM;

    // Start is called before the first frame update
    void Start()//pega checkpoint e vida inicial do jogador
    {
        rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();
        checkpointHeal = playCon.HP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)//salva checkpoint, cura jogador
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(textpoint, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), textpoint.transform.rotation);
            playCon.HP = checkpointHeal;
            rB.lastCheckpointPos = transform.position;

            if (keyM)
            {
                if (keyM.keyGottenA)
                {
                    RespawnBrain.instance.keyA = true;
                }
                if (keyM.keyGottenB)
                {
                    RespawnBrain.instance.keyB = true;
                }
            }

            Destroy(gameObject);
        }
    }
}
