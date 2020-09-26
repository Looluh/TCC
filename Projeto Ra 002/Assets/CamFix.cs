using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFix : MonoBehaviour
{
    public Vector3 fix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion originalRot = transform.rotation;
        transform.rotation = Quaternion.Normalize(originalRot);
        transform.rotation = originalRot;
    }
}
