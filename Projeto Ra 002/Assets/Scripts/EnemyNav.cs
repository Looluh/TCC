using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    //inclui TakeDamageEnemy

    public NavMeshAgent agent;
    public GameObject target;

    //public Animator anim;

    public bool iFrames = false;
    public bool stunFrames = false;
    public float HP;
    public enum IaState
    {
        Asleep,
        Follow,
        Attack,
        Hurt,
        Stun,
        Dying,
        Dead,
    }
    public IaState currentState;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        currentState = IaState.Follow;
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
            case IaState.Stun:
                Stun();
                break;
            case IaState.Dying:
                Dying();
                break;
            case IaState.Dead:
                Dead();
                break;
        }
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
    void Stun()
    {
        agent.isStopped = true;
        if (!stunFrames)
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
        if (!iFrames && !stunFrames && other.gameObject.tag == "Shot")
        {
            if (HP > 0)
            {
                currentState = IaState.Hurt;
                HP--;
                StartCoroutine(IFrames());
                Destroy(other.gameObject);
            }
            else
            {
                currentState = IaState.Dead;//trocar pra dying
            }
        }
        else if (!iFrames && !stunFrames && other.gameObject.tag == "Sword")
        {
            if (HP > 0)
            {
                currentState = IaState.Hurt;
                HP--;
                StartCoroutine(IFrames());
            }
            else
            {
                currentState = IaState.Dead;//trocar pra dying
            }
        }
        else if (!stunFrames && other.gameObject.tag == "StunAttack")
        {
            if (HP > 0)
            {
                currentState = IaState.Stun;
                HP--;
                StartCoroutine(StunFrames());
            }
            else
            {
                currentState = IaState.Dead;//trocar pra dying
            }
        }

    }

    public IEnumerator IFrames()
    {
        iFrames = true;
        yield return new WaitForSeconds(1f);
        iFrames = false;
    }
    public IEnumerator StunFrames()
    {
        stunFrames = true;
        yield return new WaitForSeconds(5f);
        stunFrames = false;
    }
}
