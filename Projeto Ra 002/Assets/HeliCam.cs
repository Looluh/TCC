using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HeliCam : MonoBehaviour
{ 

 public GameObject Player;

    public Vector3 ajust;

    // Use this for initialization


    public void SetPlayer(GameObject obj)

    { 

 Player = obj;

     }



// Update is called once per frame

 void LateUpdate()
    {

        if (Player)

        {

            transform.position = Player.transform.position + ajust;

            transform.LookAt(Player.transform);


        }



} }