using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGetB : MonoBehaviour
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
                keyM.keyGottenB = true;
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        canvasCollect.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        canvasCollect.SetActive(false);
    }
}
