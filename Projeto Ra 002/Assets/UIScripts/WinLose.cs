using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject win;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            win.SetActive(true);
    }
}
