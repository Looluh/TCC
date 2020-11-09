using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGetA : MonoBehaviour
{
    public KeyMaster keyM;
    public GameObject canvasCollect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                keyM.keyGottenA = true;
                Destroy(gameObject);
                canvasCollect.SetActive(false);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasCollect.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasCollect.SetActive(false);
        }
    }

}
