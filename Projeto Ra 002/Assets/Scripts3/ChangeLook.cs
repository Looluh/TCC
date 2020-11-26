using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public string wantedTag;
    public Look look;

    public Camera newCam;
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
}
