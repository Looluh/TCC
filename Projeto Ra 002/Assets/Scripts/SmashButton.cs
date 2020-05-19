using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashButton : MonoBehaviour
{
    public float smashNo;

    public GameObject player;
    public GameObject[] begone;

    private float range;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        range = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range)
        {
            smashNo--;

            if (smashNo <= 0)
            {
                if (on)
                {
                    for (int i = 0; i < begone.Length; i++)
                    {
                        begone[i].GetComponent<Renderer>().enabled = false;
                        begone[i].GetComponent<Collider>().enabled = false;
                    }
                }

                else if (!on)
                {
                    for (int i = 0; i < begone.Length; i++)
                    {
                        begone[i].GetComponent<Renderer>().enabled = true;
                        begone[i].GetComponent<Collider>().enabled = true;
                    }
                }
            }
        }
    }
}
