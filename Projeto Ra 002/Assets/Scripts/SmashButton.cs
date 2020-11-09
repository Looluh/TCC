using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashButton : MonoBehaviour
{
    public float smashNo;

    public GameObject activated;
    public GameObject deactivated;
    public GameObject player;
    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;

    private float range;
    public bool on;

    public AudioClip audC;

    public GameObject[] dustParticles;

    // Start is called before the first frame update
    void Start()
    {
        range = 5;

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
        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range)
        {
            smashNo--;

            if (smashNo == 0)
            {
                StartCoroutine(DoorDust());

                if (on)
                {
                    for (int i = 0; i < doors.Length; i++)
                    {
                        doorAudS[i].PlayOneShot(audC);
                        doorAnim[i].SetBool("Aberto", true);
                    }

                    Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
                }

                else if (!on)
                {
                    for (int i = 0; i < doors.Length; i++)
                    {
                        doorAudS[i].PlayOneShot(audC);
                        doorAnim[i].SetBool("Aberto", false);
                    }

                    Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
                }
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
