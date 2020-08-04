using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnemyNo : MonoBehaviour
{
    public GameObject activated;
    public GameObject deactivated;

    [SerializeField]
    public float enemyNoWanted;

    public float enemyNoNow = 0;
    public GameObject enemyToCount;

    public GameObject[] begone;
    public  bool on;

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
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Entrou");
            enemyNoNow++;

            if (enemyNoNow == enemyNoWanted)
            {
                Debug.Log("Mesmo número");

                if (on)
                {
                    Off();
                }
                else if (!on)
                {
                    On();
                }
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

    void On()
    {
        for (int i = 0; i < begone.Length; i++)
        {
            begone[i].GetComponent<Renderer>().enabled = false;
            begone[i].GetComponent<Collider>().enabled = false;
        }
        on = true;

        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < begone.Length; i++)
        {
            begone[i].GetComponent<Renderer>().enabled = true;
            begone[i].GetComponent<Collider>().enabled = true;
        }
        on = false;

        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

}

