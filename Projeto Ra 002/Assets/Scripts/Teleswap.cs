using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Teleswap : MonoBehaviour
{
    public GameObject player;
    public GameObject brain;

    public Transform playerPos;
    public Transform myself;
    public Transform brainPos;

    public AudioSource audS;
    public AudioClip audC;

    public PlayerController pC;
    public float currCountdownValue;
    public bool cooldown = false;

    public CharacterController playerCC;

    public bool ccOn = true;
    // Start is called before the first frame update
    void Start()//jogador, brain, playercontroller
    {
        player = GameObject.FindGameObjectWithTag("Player");
        brain = GameObject.FindWithTag("SwapBrain");

        playerPos = player.transform;
        brainPos = brain.transform;
        //pC = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!ccOn)
            playerCC.enabled = false;
        else if (ccOn)
            playerCC.enabled = true;
        */
    }

    //private void OnTriggerEnter(Collider other)//verifica tiro no trigger
    //{
    //    if (other.gameObject.CompareTag("Shot") && !cooldown)
    //    {
    //        StartCoroutine(TeleCountdown());
    //    }
    //}

    private void OnCollisionEnter(Collision collision)//verifica tiro no collider
    {
        if (collision.gameObject.CompareTag("Shot") && !cooldown)
        {
            StartCoroutine(TeleCountdown());
        }
    }

    public void Teleport()//teleporta de maneira triangular, 
    {
        brainPos.position = playerPos.position;

        playerCC.enabled = false;
        //ccOn = false;
        //Destroy(playerCC);
        //playerPos.position = new Vector3(myself.position.x, playerPos.position.y + 0.15f, myself.position.z);
        pC.Teleport(new Vector3(myself.position.x, playerPos.position.y + 0.15f, myself.position.z));

        //ccOn = true;
        playerCC.enabled = true;

        myself.transform.position = new Vector3(brainPos.position.x, myself.position.y, brainPos.position.z);

        audS.PlayOneShot(audC);

        StartCoroutine(StartCountdown());
    }
    public IEnumerator StartCountdown(float countdownValue = 2)//inicia cooldown
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        if (currCountdownValue <= 0)
        {
            cooldown = false;

            Debug.Log("enum");
        }
    }

    public IEnumerator TeleCountdown()//espera um pouco antes de teleportar, altera estado do jogador
    {
        cooldown = true;
        Debug.Log("TeleCountdown");
        pC.currentState = PlayerController.PlayerState.Canalization;
        yield return new WaitForSeconds(1.0f);
        //pC.currentState = PlayerController.PlayerState.Idle;
        Teleport();
    }

}
