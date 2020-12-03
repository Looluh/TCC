using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleshot : MonoBehaviour
{
    public GameObject player;

    public Transform playerPos;
    public Transform myself;
    public bool cooldown = false;
    public float currCountdownValue;

    public TextureBlink[] tB;

    public PlayerController pC;

    public CharacterController playerCC;

    public Vector3 place;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        tB = GetComponentsInChildren<TextureBlink>();
        place = new Vector3(myself.position.x, playerPos.position.y + 0.15f, myself.position.z);

        //pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shot") && !cooldown)
        {
            StartCoroutine(TeleCountdown());
        }
    }

    public void Teleport()
    {
        Debug.Log("pos original player " + playerPos.position);
        //playerCC.Move(Vector3.zero);
        playerCC.enabled = false;
        pC.enabled = false;
        //playerPos.parent = playerCC.transform;

        //playerPos.position = place;
        pC.Teleport(place);

        //playerPos.SetPositionAndRotation(place, Quaternion.identity);
        //playerPos.position.Set(place.x, place.y, place.z);
        Debug.Log("pos original obj " + place);
        pC.enabled = true;
        playerCC.enabled = true;
        Debug.Log("pos final player " + playerPos.position);
        StartCoroutine(StartCountdown());
        
    }

    public IEnumerator StartCountdown(float countdownValue = 2)
    {
        for (int i = 0; i < tB.Length; i++)
        {
            tB[i].colorNow = tB[i].redd;
        }
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
            for (int i = 0; i < tB.Length; i++)
            {
                tB[i].colorNow = tB[i].gren;
            }

            Debug.Log("enum");
        }
    }

    public IEnumerator TeleCountdown()
    {
        cooldown = true;
        Debug.Log("TeleCountdown");
        pC.currentState = PlayerController.PlayerState.Canalization;
        yield return new WaitForSeconds(1.0f);
        //pC.currentState = PlayerController.PlayerState.Idle;
        Debug.Log("teleport");

        Teleport();
    }

}
