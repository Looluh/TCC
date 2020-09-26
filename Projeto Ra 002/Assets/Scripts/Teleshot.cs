using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleshot : MonoBehaviour
{
    public Transform player;
    public Transform myself;
    public bool cooldown = false;
    public float currCountdownValue;


    public TextureBlink[] tB;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1").transform;
        tB = GetComponentsInChildren<TextureBlink>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shot") && !cooldown)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(myself.transform.position.x, player.transform.position.y, myself.transform.position.z);
            player.GetComponent<CharacterController>().enabled = true;
            StartCoroutine(StartCountdown());
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 2)
    {
        for (int i = 0; i < tB.Length; i++)
        {
            tB[i].colorNow = tB[i].redd;
        }
        currCountdownValue = countdownValue;
        cooldown = true;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        if (currCountdownValue <= 0)
        {
            cooldown = false;
            for (int i = 0; i < tB.Length; i++)
            {
                tB[i].colorNow = tB[i].gren;
            }

            Debug.Log("enum");
        }
    }
}
