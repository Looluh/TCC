using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtTimedButtonOff : MonoBehaviour
{
    //começa ligado e aí desliga
    public GameObject player;
    public GameObject[] begone;
    public float currCountdownValue;

    public bool on;

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
        for (int i = 0; i < begone.Length; i++)
        {
            begone[i].GetComponent<Renderer>().enabled = false;
            begone[i].GetComponent<Collider>().enabled = false;
        }
        on = true;
    }

    void Off()
    {
        for (int i = 0; i < begone.Length; i++)
        {
            begone[i].GetComponent<Renderer>().enabled = true;
            begone[i].GetComponent<Collider>().enabled = true;
        }
        on = false;
    }

    //yield break;
}

