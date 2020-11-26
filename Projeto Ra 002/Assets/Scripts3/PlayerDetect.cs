using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public EnemyNav enNav;
    public bool attacking = false;

    // Start is called before the first frame update
    void Start()//pega script da AI do inimigo
    {
        enNav = GetComponentInParent<EnemyNav>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)//detecta se o jogador tá no trigger
    {
        if (other.gameObject.CompareTag("Player") && !enNav.attacking)//!attacking
        {
            if (enNav.currentState != EnemyNav.IaState.Dying && enNav.currentState != EnemyNav.IaState.Stun)
            {
                StartCoroutine(Attack());
            }
        }
    }

    public IEnumerator Attack()//ataca, espera pra atacar dnv
    {
        attacking = true;
        enNav.currentState = EnemyNav.IaState.Attack;
        yield return new WaitForSeconds(0.8f);
        attacking = false;
    }
}
