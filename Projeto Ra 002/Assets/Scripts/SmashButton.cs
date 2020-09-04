using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashButton : MonoBehaviour
{
    public float smashNo;

    public GameObject activated;
    public GameObject deactivated;
    public GameObject player;
    public Animator[] anim;


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

            if (smashNo == 0)
            {
                if (on)
                {
                    for (int i = 0; i < anim.Length; i++)
                    {
<<<<<<< Updated upstream
                        anim[i].Play("DoorOpen");
=======
                        anim[i].SetBool("Aberto", true);
>>>>>>> Stashed changes
                    }

                    Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
                }

                else if (!on)
                {
                    for (int i = 0; i < anim.Length; i++)
                    {
<<<<<<< Updated upstream
                        anim[i].Play("DoorClose");
=======
                        anim[i].SetBool("Aberto", false);
>>>>>>> Stashed changes
                    }

                    Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
                }
            }
        }
    }
}
