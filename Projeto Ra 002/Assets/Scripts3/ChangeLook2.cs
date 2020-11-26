using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook2 : MonoBehaviour
{
    public string wantedTag;
    public Look look;

    public Camera newCam;
    public Camera oldCam;
    // Start is called before the first frame update
    void Start()
    {
        look = GameObject.FindGameObjectWithTag("Firepoint").GetComponent<Look>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(wantedTag))
        {
            look.mainCamera = newCam;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(wantedTag))
        {
            look.mainCamera = oldCam;
        }
    }
}
