using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMaster : MonoBehaviour
{
    public PatternButton[] patButt;


    public AudioClip audC;

    public GameObject[] doors;
    public bool isDoorClosed;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;
    public GameObject[] dustParticles;

    public GameObject player;

    public bool[] patBool;
    // Start is called before the first frame update
    void Start()
    {
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

    public void VerifyPattern()
    {
        if (patButt[0].on == patBool[0] &&
            patButt[1].on == patBool[1] &&
            patButt[2].on == patBool[2] &&
            patButt[3].on == patBool[3] &&
            patButt[4].on == patBool[4])
        {
            StartCoroutine(DoorDust());

            for (int i = 0; i < doors.Length; i++)
            {
                doorAudS[i].PlayOneShot(audC);

                if (isDoorClosed)
                    doorAnim[i].SetBool("Aberto", true);
                else
                    doorAnim[i].SetBool("Aberto", false);
            }
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
