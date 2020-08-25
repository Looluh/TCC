using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    //public Animator anim;

    public bool iFrames = false;
    public float HP;
    public enum IaState
    {
        Asleep,
        Follow,
        Attack,
        Hurt,
        Dying,
        Dead,
    }
    public IaState currentState;

    // Start is called before the first frame update
    void Start()
    {
        Follow();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case IaState.Asleep:
                Asleep();
                break;
            case IaState.Follow:
                Follow();
                break;
            case IaState.Attack:
                Attack();
                break;
            case IaState.Hurt:
                Hurt();
                break;
            case IaState.Dying:
                Dying();
                break;
            case IaState.Dead:
                Dead();
                break;
        }


        //agent.SetDestination(target.transform.position);


    }

    void Asleep()
    {

    }
    void Follow()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        //anim.SetBool("Attack", false);

    }

    void Attack()
    {

    }

    void Hurt()
    {
        agent.isStopped = true;

        //anim.SetTrigger("Hit");
        if (!iFrames)
        {
            currentState = IaState.Follow;
        }

    }
    void Dying()
    {
        agent.isStopped = true;
        //anim.SetBool("Attack", false);
        //currentState = IaState.Follow;

    }

    void Dead()
    {
        agent.isStopped = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!iFrames && other.gameObject.tag == "Shot")
        {
            if (HP > 0)
            {
                HP--;
                StartCoroutine(TakeDamage());

                currentState = IaState.Hurt;
                Destroy(other.gameObject);
            }
            else
            {
                currentState = IaState.Dead;//trocar pra dying
            }
        }
        else if (!iFrames && other.gameObject.tag == "Sword")
        {
            if (HP > 0)
            {
                HP--;
                StartCoroutine(TakeDamage());

                currentState = IaState.Hurt;
            }
            else
            {
                currentState = IaState.Dead;//trocar pra dying
            }
        }

    }

    public IEnumerator TakeDamage()
    {
        iFrames = true;
        yield return new WaitForSeconds(5f);
        iFrames = false;
    }

}
