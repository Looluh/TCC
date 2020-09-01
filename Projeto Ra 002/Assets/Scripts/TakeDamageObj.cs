using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageObj : MonoBehaviour
{
    public float HP = 3;
   // public bool iFrames;

    //public GameObject enm;

    // Start is called before the first frame update
    void Start()
    {
      //  iFrames = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Shot" || col.collider.tag == "Sword")
        {
            
            HP--;
        }

    }

    

   
}

