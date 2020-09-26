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

    public Animator[] anim;
    public  bool on;

    public bool done = false;

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
        if (other.gameObject.CompareTag("Enemy") && !done)
        {
            Debug.Log("Entrou");
            enemyNoNow++;

            if (enemyNoNow == enemyNoWanted)
            {
                Debug.Log("Mesmo número");
                done = true;
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
        if (other.gameObject.CompareTag("Enemy") && !done)
        {
            Debug.Log("Saiu");
            enemyNoNow--;
        }
    }

    void On()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", true);
        }
        //on = true;

        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    void Off()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Aberto", false);
        }
        //on = false;

        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

}

