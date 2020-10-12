using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public bool on;
    private float range;

    public GameObject activated;
    public GameObject deactivated;
    public GameObject player;
    public Animator[] anim;
    public bool ok = true;

    public Animator glowA;
    public Light glowL;
    public Material glowM;

    public bool frog;
    public bool owl;
    public bool dragonfly;
    public bool hippo;

    public Color frogC;
    public Color owlC;
    public Color dragonflyC;
    public Color hippoC;

    public BallGlow balGlo;
    public enum ColorGlow
    {
        Frog,
        Owl,
        Dragonfly,
        Hippo,
    }
    public ColorGlow currColorGlow;

    // Start is called before the first frame update
    void Start()
    {
        range = 5;

        if (frog)
        {
            glowM.SetColor("_EmissionColor", frogC);
            glowL.color = frogC;
            currColorGlow = ColorGlow.Frog;
        }
        else if (owl)
        {
            glowM.SetColor("_EmissionColor", owlC);
            glowL.color = owlC;
            currColorGlow = ColorGlow.Owl;
        }
        else if (dragonfly)
        {
            glowM.SetColor("_EmissionColor", dragonflyC);
            glowL.color = dragonflyC;
            currColorGlow = ColorGlow.Dragonfly;
        }
        else if (hippo)
        {
            glowM.SetColor("_EmissionColor", hippoC);
            glowL.color = hippoC;
            currColorGlow = ColorGlow.Hippo;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && !on && ok)// /?
        {
            On();
            StartCoroutine("OkCheck");
        }
        else if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && on && ok)// /?
        {
            Off();
            StartCoroutine("OkCheck");
        }//else if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && on && anim[].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))// /?

    }

    //if (anim[i].GetCurrentAnimatorStateInfo(0).normalizedTime <= 0 && anim[i].IsInTransition(0))
    //should do: checks if animation is playing then check if it is transitioning

    void On()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            //anim[i].Play("DoorClose");
            anim[i].SetBool("Aberto", false);
        }


        on = true;
        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            //anim[i].Play("DoorOpen");
            anim[i].SetBool("Aberto", true);
        }

        on = false;
        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    public IEnumerator OkCheck()
    {
        ok = false;

        switch (currColorGlow)
        {
            case ColorGlow.Frog:
                balGlo.Green();
                break;
            case ColorGlow.Owl:
                balGlo.Brown();
                break;
            case ColorGlow.Dragonfly:
                balGlo.Purple();
                break;
            case ColorGlow.Hippo:
                balGlo.Aqua();
                break;
        }

        glowA.SetTrigger("Glow");

        yield return new WaitForSeconds(2f);
        ok = true;
    }
}

