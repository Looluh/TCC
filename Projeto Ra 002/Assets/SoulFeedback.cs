using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFeedback : MonoBehaviour
{
    public GameObject enemy;
    public EnemyNav enNav;
    public GameObject soul;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        enNav = GetComponent<EnemyNav>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( enNav.currentState == EnemyNav.IaState.Dying)
        {
            Instantiate(soul, enemy.transform.position, enemy.transform.rotation);
            Destroy(this);
        }
    }
}
