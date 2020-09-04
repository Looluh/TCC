using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float maxEnemies;
    public bool doing = false;
    public GameObject enemy;//prefab do inimigo

    //public GameObject pos;
    public Vector3[] pos;

    public enum spawnerState
    {
        On,
        Off,
    }
    public spawnerState state;

    // Start is called before the first frame update
    void Start()
    {
        state = spawnerState.Off;
    }


    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case spawnerState.On:
                On();
                break;
            case spawnerState.Off:
                Off();
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state = spawnerState.On;
        }
    }

    void Off()
    {

    }
    void On()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies && !doing)
        {
            doing = !doing;
            StartCoroutine(SpawnEnemies());
        }
    }

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(enemy, pos[i], Quaternion.identity);
        }
        yield return new WaitForSeconds(4.0f);
        doing = !doing;
    }

}

