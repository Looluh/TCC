using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject textpoint;

    private RespawnBrain rB;
    public TakeDamagePlayer tdP;
    public float checkpointHeal;

    // Start is called before the first frame update
    void Start()
    {
        rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();
        checkpointHeal = tdP.HP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(textpoint, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), textpoint.transform.rotation);
            tdP.HP = checkpointHeal;
            rB.lastCheckpointPos = transform.position;
            Destroy(gameObject);
        }
    }
}
