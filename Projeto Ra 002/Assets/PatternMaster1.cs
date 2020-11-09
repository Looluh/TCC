using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMaster1 : MonoBehaviour
{
    public PatternButton[] patButt;

    //public GameObject player;

    public Animator wallAnim;
    public AudioClip wallAudC;
    public GameObject wall;
    public AudioSource wallAudS;

    public bool[] patBool;

    // Start is called before the first frame update
    void Start()
    {
        wallAnim = wall.GetComponent<Animator>();
        wallAudS = wall.GetComponent<AudioSource>();
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
            wallAudS.PlayOneShot(wallAudC);
            wallAnim.SetBool("Down", true);
        }
    }
}
