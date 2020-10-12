using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtTimedButtonOn : MonoBehaviour
{
    //começa desligado e aí liga
    public GameObject activated;
    public GameObject deactivated;
    public GameObject player;
    public float currCountdownValue;
    public Animator[] anim;

    private bool on;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Shot") && !on)//adicionar limitador
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

        currCountdownValue = countdownValue;
        Off();
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.05f);
            currCountdownValue--;
        }

        if(currCountdownValue <= 0)
        {
            On();
            Debug.Log("enum");
        }
    }

    void On()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", true);
        }

        on = false;

        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", false);
        }

        on = true;

        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    //yield break;
}

