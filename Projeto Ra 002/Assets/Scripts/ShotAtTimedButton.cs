using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtTimedButton : MonoBehaviour
{
    public float range;

    public GameObject player;
    public GameObject begone;
    public float currCountdownValue;

    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        range = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot" && !on)//adicionar limitador
        {
            StartCoroutine(StartCountdown());
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        On();
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        if(currCountdownValue <= 0)
        {
            Off();
            Debug.Log("enum");
        }
    }

    void On()
    {
        begone.GetComponent<Renderer>().enabled = false;
        begone.GetComponent<Collider>().enabled = false;
        on = true;
    }

    void Off()
    {
        begone.GetComponent<Renderer>().enabled = true;
        begone.GetComponent<Collider>().enabled = true;
        on = false;
    }

    //yield break;
}

