using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMaster : MonoBehaviour
{
    public bool keyGottenA;
    public bool keyGottenB;

    public RotateStatue rotStat;

    public GameObject keyA;
    public GameObject keyB;

    public bool doneA;
    public bool doneB;

    public GameObject canvasPlace;
    // Start is called before the first frame update
    void Start()
    {
        if (RespawnBrain.instance.keyA)
            keyGottenA = true;
        if (RespawnBrain.instance.keyB)
            keyGottenB = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doneA && keyGottenA && Input.GetButton("Interact"))
            {
                doneA = true;
                rotStat.keyA = true;
                keyA.SetActive(true);
            }
            if (!doneB && keyGottenB && Input.GetButton("Interact"))
            {
                doneB = true;
                rotStat.keyB = true;
                keyB.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasPlace.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasPlace.SetActive(false);
        }
    }

}
