using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedButtonOff : MonoBehaviour
{
    //começa ligado e aí desliga
    public GameObject activated;
    public GameObject deactivated;

    private float range;

    public GameObject player;
    public float currCountdownValue;
    public Animator[] anim;

    public bool on;

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
        on = false;
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

        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && !on)// /?
        {
            StartCoroutine(StartCountdown());
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
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

        currCountdownValue = countdownValue;
        On();
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        if (currCountdownValue <= 0)
        {
            Off();
            Debug.Log("enum");
        }
    }

    void On()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", false);
        }
        on = true;

        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", true);
        }
        on = false;

        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    //yield break;
}

