using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGetB : MonoBehaviour
{
    public KeyMaster keyM;
    public GameObject canvasCollect;

    private void OnTriggerStay(Collider other)//verifica se o jogador tá perto o suficiente e se ele apertar E
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                keyM.keyGottenB = true;
                Destroy(gameObject);
                canvasCollect.SetActive(false);
            }
        }

    }
    private void OnTriggerEnter(Collider other)//aparece hint de como coletar chave
    {
        if (other.CompareTag("Player"))
        {
            canvasCollect.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)//desaparece hint de como coletar chave
    {
        if (other.CompareTag("Player"))
        {
            canvasCollect.SetActive(false);
        }
    }
}
