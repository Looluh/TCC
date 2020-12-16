using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject win;

    public PlayerController playCon;

    public GameObject player;

    //public Collider[] playerCol;

    //public Collider enVerifyPlayer;
    private void Start()//pega o jogador, dá o level como iniciado
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerCol = player.GetComponents<Collider>();
        //playCon = player.GetComponent<PlayerController>();
        RespawnBrain.instance.gameState = true;
    }
    private void OnTriggerEnter(Collider other)//verifica se é o jogador e seu estado, muda estado, finaliza jogo, deixa o jogo mais lento e invoca win
    {
        if (other.CompareTag("Player") && playCon.currentState != PlayerController.PlayerState.Victory)
        {
            playCon.currentState = PlayerController.PlayerState.Victory;
            RespawnBrain.instance.gameState = false;

            Time.timeScale = 0.1f;

            //for (int i = 0; i < playerCol.Length; i++)
            //    playerCol[i].enabled = false;

            Invoke("Win", 0.4f);
        }
    }

    public void Win()//volta o jogo pra velocidade normal, instancia mensagem de vitória
    {
        Time.timeScale = 1;
        win.SetActive(true);
    }
}
