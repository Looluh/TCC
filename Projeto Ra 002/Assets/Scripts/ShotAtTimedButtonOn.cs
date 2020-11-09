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
    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;

    private bool on;

    public BallGlow balGlo;

    public AudioClip audC;

    public GameObject[] dustParticles;

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
        for (int i = 0; i < doors.Length; i++)
        {
            doorAnim[i] = doors[i].GetComponent<Animator>();
            doorAudS[i] = doors[i].GetComponent<AudioSource>();
            dustParticles[i] = doors[i].transform.GetChild(0).gameObject;
        }
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
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", true);
        }
        StartCoroutine(DoorDust());

        on = false;

        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", false);
        }
        StartCoroutine(DoorDust());

        on = true;

        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }
    public IEnumerator DoorDust()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            dustParticles[i].SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < doors.Length; i++)
        {
            dustParticles[i].SetActive(false);
        }
    }

    //yield break;
}

