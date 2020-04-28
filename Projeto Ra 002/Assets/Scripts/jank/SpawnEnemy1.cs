using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy1 : MonoBehaviour
{
    public float maxEnemies;
    public bool doing = false;
    public GameObject enemy;

    public GameObject pos;
    //public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies && !doing)
        {
            doing = !doing;
            StartCoroutine(SpawnEnemies());

        }
    }

    public IEnumerator SpawnEnemies()
    {
        Instantiate(enemy, pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4.0f);
        doing = !doing;
    }

}

