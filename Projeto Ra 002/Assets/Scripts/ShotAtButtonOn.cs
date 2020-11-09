using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtButtonOn : MonoBehaviour
{
    //começa desligado e aí liga
    public GameObject activated;
    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;
    public bool done = false;

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

    void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAnim[i] = doors[i].GetComponent<Animator>();
            doorAudS[i] = doors[i].GetComponent<AudioSource>();
            dustParticles[i] = doors[i].transform.GetChild(0).gameObject;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Shot") && !done)
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
            StartCoroutine(DoorDust());

            for (int i = 0; i < doors.Length; i++)
            {
                doorAudS[i].PlayOneShot(audC);
                doorAnim[i].SetBool("Aberto", false);
            }
            done = true;
            Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
        }
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

}

