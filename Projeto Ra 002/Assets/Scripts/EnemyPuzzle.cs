using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPuzzle : MonoBehaviour
{

    
    public GameObject zumbi;
    [SerializeField]
    public float enemyNoWanted;
    public float enemyNoNow = 0;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
      //  foreach (EnemyBasic enemy in collision.contacts)
      //  {
      //      enemyNoNow++;
      //  }
      //  foreach (/*colision.gameObject.tag="zumbi"*/GameObject zumbi in collision)
      //  {
      //      
      //  }
        if(collision.gameObject.tag == "zumbi")
        {
            enemyNoNow++;
        }
        if (enemyNoNow == enemyNoWanted)
        {
            //do shit
        }
    }
}

