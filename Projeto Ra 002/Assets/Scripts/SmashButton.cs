using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashButton : MonoBehaviour
{
    public float smashNo;

    public GameObject player;
    public GameObject begone;

    public float range;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range)
        {
            smashNo--;

            if (smashNo <= 0)
            {
                begone.GetComponent<Renderer>().enabled = false;
                begone.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
