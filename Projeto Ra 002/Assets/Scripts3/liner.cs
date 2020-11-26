using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liner : MonoBehaviour
{
    public GameObject cubeBottom;
    public GameObject cubeTop;


    void Start()
    {
        //cubeBottom = GameObject.Find("go1");

        //cubeTop = GameObject.Find("go2");

    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, cubeBottom.transform.localPosition);
        lineRenderer.SetPosition(1, cubeTop.transform.localPosition);
    }
}
