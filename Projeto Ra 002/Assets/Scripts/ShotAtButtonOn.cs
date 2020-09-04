using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtButtonOn : MonoBehaviour
{
    //começa desligado e aí liga
    public GameObject activated;
    public Animator[] anim;
    public bool done = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot" && !done)
        {
            for (int i = 0; i < anim.Length; i++)
            {
                anim[i].SetBool("Aberto", false);
            }
            done = true;
            Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
        }
    }


}

