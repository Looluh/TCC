using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject win;

    public PlayerController playCon;

    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playCon = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playCon.currentState != PlayerController.PlayerState.Victory)
        {
            playCon.currentState = PlayerController.PlayerState.Victory;
            Time.timeScale = 0.1f;

            player.GetComponent<Collider>().enabled = false;

            Invoke("Win", 0.4f);
        }
    }

    public void Win()
    {
        Time.timeScale = 1;
        win.SetActive(true);
    }
}
