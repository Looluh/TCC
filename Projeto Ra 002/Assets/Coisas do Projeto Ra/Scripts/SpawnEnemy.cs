using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float maxEnemies;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Zumbi").Length < maxEnemies)
        {
            Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);//alterar o "0, 0, 0," pra posição que vc quer
            //yield return new WaitForSeconds(1.0f);//se isso não funcionar, só tira

        }
    }



}

