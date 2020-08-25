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

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        range = 5;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (currCountdownValue <= 0)
        {
            on = false;
            debug.Log("if");
        }*/

        if (Input.GetKeyDown(KeyCode.E) && (player.transform.position - transform.position).sqrMagnitude < range * range && !on)// /?
        {
            Debug.Log("Cu1");
            //On();
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
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].Play("DoorClose");
        }
        on = true;

        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].Play("DoorOpen");
        }
        on = false;

        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    //yield break;
}

