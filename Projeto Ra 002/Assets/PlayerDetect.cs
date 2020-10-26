using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public EnemyNav enNav;
    public bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        enNav = GetComponentInParent<EnemyNav>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !attacking)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        attacking = true;
        enNav.currentState = EnemyNav.IaState.Attack;
        yield return new WaitForSeconds(0.8f);
        attacking = false;
    }
}
