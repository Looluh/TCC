using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    //inclui TakeDamageEnemy

    public NavMeshAgent agent;
    public GameObject target;

    public Animator anim;

    public bool iFrames = false;
    public bool stunFrames = false;
    public float HP;

    public float enSpeed;

    //public GameObject handColEsq;
    //public GameObject handColDir;
    //public GameObject armColEsq;
    //public GameObject armColDir;
    public GameObject[] attackCol;
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
        //attackCol = GameObject.FindGameObjectsWithTag("attackCol");
        //handColEsq = GameObject.Find("HandColEsq");
        //handColDir = GameObject.Find("HandColDir");
        //armColEsq = GameObject.Find("ArmColEsq");
        //armColDir = GameObject.Find("ArmColDir");

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = Random.Range(5, 20);
        anim.SetFloat("Velocity", agent.speed / 5);

        if (agent.speed > 10)
        {
            anim.SetInteger("SpeedVerifier", 2);
        }
        else
        {
            anim.SetInteger("SpeedVerifier", 1);
        }
        currentState = IaState.Follow;
        target = GameObject.FindGameObjectWithTag("Player");

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

        if (anim.GetCurrentAnimatorStateInfo(1).IsName("Ataque"))
        {
            for (int i = 0; i < attackCol.Length; i++)
            {
                attackCol[i].SetActive(true);
                Debug.Log("atkCOlOn");
            }
        }
        else
        {
            for (int i = 0; i < attackCol.Length; i++)
            {
                attackCol[i].SetActive(false);
                Debug.Log("atkColOff");
            }

        }

    }

    void Asleep()
    {
    }
    public bool atkColDone = true;
    void Follow()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        RotateTowards(target.transform);

        //if (agent.speed > 10)
        //{
        //    anim.SetInteger("SpeedVerifier", 2);
        //}
        //else
        //{
        //    anim.SetInteger("SpeedVerifier", 1);
        //}


    }
    void Attack()
    {
        Debug.Log("attack");
        RotateTowards(target.transform);
        //anim.speed = 1;
        agent.isStopped = true;//?
        anim.SetTrigger("Attack");
        currentState = IaState.Follow;
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
        anim.speed = 0;
    }

    public void AtkIn()
    {
        for (int i = 0; i < attackCol.Length; i++)
        {
            attackCol[i].SetActive(true);
        }
    }
    public void AtkOut()
    {
        for (int i = 0; i < attackCol.Length; i++)
        {
            attackCol[i].SetActive(false);
        }
    }

    public float rotationSpeed = 10f;
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!iFrames && !stunFrames && other.gameObject.CompareTag("Shot"))
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
        else if (!iFrames && !stunFrames && other.gameObject.CompareTag("Sword"))
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
        else if (!stunFrames && other.gameObject.CompareTag("StunAttack"))
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
