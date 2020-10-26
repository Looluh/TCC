using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject win;

    public PlayerController playCon;

    private void Start()
    {
        playCon = GameObject.Find("PlayerChar").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playCon.currentState != PlayerController.PlayerState.Victory)
        {
            playCon.currentState = PlayerController.PlayerState.Victory;
            Invoke("Win", 4);
        }
    }

    public void Win()
    {
        win.SetActive(true);
    }
}
