using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    public Animator animator;
    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        Off();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !on)
        {
            StartCoroutine(Swing());
        }
    }

    public IEnumerator Swing()
    {
        On();
        on = !on;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(.34f);//trocar pra esperar a animação
        //iFrames = false;
        on = !on;
        Off();
    }

    void Off()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        //on = true;
    }

    void On()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
        //on = false;
    }

}

