using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int maxEnemiesTotal;
    public bool doing = false;
    public GameObject enemy;//prefab do inimigo

    //public GameObject pos;
    public GameObject[] pos;

    public int maxEnemiesCounter;
    public int enCounter;
    public enum SpawnerState
    {
        On,
        Off,
    }
    public SpawnerState state;

    public GameObject[] newEnemy;
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        //state = SpawnerState.Off;
        enCounter = 0;
        col = GetComponent<Collider>();
        //enCounter = new int[maxEnemiesTotal];
        //InvokeRepeating("On", 15f, 12f);
    }


    // Update is called once per frame
    void Update()
    {
        //maxEnemiesTotal = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //switch (state)
        //{
        //    case SpawnerState.On:
        //        On();
        //        break;
        //    case SpawnerState.Off:
        //        Off();
        //        break;
        //    default:
        //        break;
        //}


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !doing)
        {
            doing = true;
            col.enabled = false;
            //state = SpawnerState.On;
            InvokeRepeating("Off", 4, 4);
            //InvokeRepeating("On", 15f, 12f);
        }
    }

    void Off()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (enCounter < maxEnemiesCounter && (enCounter - maxEnemiesCounter) < GameObject.FindGameObjectsWithTag("Enemy").Length)//&& enCounter < maxEnemiesTotal
            {

                //Instantiate(enemy, pos[i].transform.position, Quaternion.identity);
                newEnemy[enCounter % newEnemy.Length] = Instantiate(enemy, pos[i].transform.position, Quaternion.identity);//pos[i].
                enCounter++;

            }
        }
        if (enCounter == maxEnemiesCounter)
        {
            for (int c = 0; c < newEnemy.Length; c++)
            {

                if (newEnemy[c] == null)
                {
                    print(c);
                    maxEnemiesCounter++;
                    //maxEnemiesCounter = Mathf.Clamp(maxEnemiesCounter, 0, maxEnemiesTotal);
                }
            }
        }

    }
    void On()
    {
        for (int i = 0; i < newEnemy.Length; i++)
        {

            if (newEnemy[i] == null)
            {
                print(i);
                maxEnemiesCounter++;
            }
        }

    }

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            //Instantiate(enemy, pos[i].transform.position, Quaternion.identity);
            newEnemy[enCounter % 3] = Instantiate(enemy, pos[i].transform.position, Quaternion.identity);
            enCounter++;
        }
        yield return new WaitForSeconds(4.0f);
        doing = false;
    }

}

