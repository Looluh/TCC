using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtButtonOff : MonoBehaviour
{
    //começa ligado e aí desliga
    public GameObject deactivated;
    public Animator[] anim;
    public bool done;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot")
        {
            for (int i = 0; i < anim.Length; i++)
            {
                anim[i].SetBool("Aberto", true);
            }
            done = true;
            Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
        }
    }


}

