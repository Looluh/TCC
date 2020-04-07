using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnemyNo : MonoBehaviour
{
    [SerializeField]
    public float enemyNoWanted;

    public float enemyNoNow = 0;

    public GameObject enemyToCount;

    public GameObject begone;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zumbi")
        {
            Debug.Log("Entrou");
            enemyNoNow++;

            if (enemyNoNow == enemyNoWanted)
            {
                Debug.Log("Mesmo número");
                begone.GetComponent<Renderer>().enabled = false;
                begone.GetComponent<Collider>().enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Zumbi")
        {
            Debug.Log("Saiu");
            enemyNoNow--;
        }
    }
}

