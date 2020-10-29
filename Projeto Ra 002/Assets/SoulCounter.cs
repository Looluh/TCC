using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCounter : MonoBehaviour
{
    public GameObject activated;
    public GameObject deactivated;

    public int soulWanted;
    public int soulNow;

    public Animator[] anim;
    public bool on;

    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Count()
    {
        soulNow++;

        if (soulNow >= soulWanted && !done)
        {
            done = true;
            if (on)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }

    void On()//abre
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", true);
        }
        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    void Off()//fecha
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", false);
        }
        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }
}
