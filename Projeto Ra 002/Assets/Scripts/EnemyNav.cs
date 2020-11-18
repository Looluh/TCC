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
    public bool attacking = false;
    public float HP;

    public float enSpeed;

    //public GameObject handColEsq;
    //public GameObject handColDir;
    //public GameObject armColEsq;
    //public GameObject armColDir;
    public GameObject[] attackCol;

    public Material enMat;

    public GameObject playerDetect;
    public GameObject enDeadParticle;

    public bool startAsleep;
    public enum IaState
    {
        Asleep,
        Follow,
        Look,
        Attack,
        Hurt,
        Stun,
        Dying,
    }
    public IaState currentState;

    public enum FollowState
    {
        Walk,
        Run,
    }

    public FollowState currentFollow;
    // Start is called before the first frame update
    void Start()
    {
        //attackCol = GameObject.FindGameObjectsWithTag("attackCol");
        //handColEsq = GameObject.Find("HandColEsq");
        //handColDir = GameObject.Find("HandColDir");
        //armColEsq = GameObject.Find("ArmColEsq");
        //armColDir = GameObject.Find("ArmColDir");
        playerDetect = transform.GetChild(2).gameObject;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = Random.Range(5, 20);
        anim.SetFloat("Velocity", agent.speed / 5);
        enMat = GetComponentInChildren<Renderer>().material;
        if (agent.speed > 10)
        {
            //anim.SetInteger("SpeedVerifier", 2);
            currentFollow = FollowState.Run;
        }
        else
        {
            //anim.SetInteger("SpeedVerifier", 1);
            currentFollow = FollowState.Walk;
        }
        target = GameObject.FindGameObjectWithTag("Player");
        if (startAsleep)
        {
            currentState = IaState.Asleep;
            InvokeRepeating("VerifyPlayerDistance", 0.1f, 1.5f);
        }
        else
        {
            currentState = IaState.Follow;
        }
        //print(anim.speed);
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
            case IaState.Look:
                Look();
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
        }

        /*if (anim.GetCurrentAnimatorStateInfo(1).IsName("Ataque"))
        {
            for (int i = 0; i < attackCol.Length; i++)
            {
                attackCol[i].SetActive(true);
                Debug.Log("atkColOn");
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
        */
    }

    void Asleep()
    {
        //:)
    }
    void Follow()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        RotateTowards(target.transform);
        switch (currentFollow)
        {
            case FollowState.Walk:
                anim.SetInteger("SpeedVerifier", 1);
                break;
            case FollowState.Run:
                anim.SetInteger("SpeedVerifier", 2);
                break;
        }

        //if (agent.speed > 10)
        //{
        //    anim.SetInteger("SpeedVerifier", 2);
        //}
        //else
        //{
        //    anim.SetInteger("SpeedVerifier", 1);
        //}
    }
    void Look()
    {
        agent.SetDestination(target.transform.position);
        RotateTowards(target.transform);
    }
    void Attack()
    {
        Debug.Log("attack");
        RotateTowards(target.transform);
        //anim.speed = 1;
        //agent.isStopped = true;//?
        StartCoroutine(AttackCol());
        anim.SetTrigger("Attack");
        currentState = IaState.Look;
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
        enMat.color = Color.blue;
        enMat.SetColor("_EmissionColor", Color.blue);
        agent.isStopped = true;
        anim.speed = 0;
        if (!stunFrames)
        {
            anim.speed = 1;
            enMat.color = Color.white;
            enMat.SetColor("_EmissionColor", Color.white);
            currentState = IaState.Follow;
        }

    }
    void Dying()
    {
        Destroy(playerDetect);
        enMat.SetVector("_EmissionColor", Color.white * 1000f);
        agent.isStopped = true;
        anim.speed = 0;
        StartCoroutine(Dead());
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
                currentState = IaState.Dying;//trocar pra dying
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
                currentState = IaState.Dying;//trocar pra dying
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
                currentState = IaState.Dying;//trocar pra dying
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

    public IEnumerator AttackCol()
    {
        if (!attacking)
        {
            attacking = true;
            for (int i = 0; i < attackCol.Length; i++)
            {
                attackCol[i].SetActive(true);
                Debug.Log("atkColOn");
            }
            yield return new WaitForSeconds(1.3f);
            for (int i = 0; i < attackCol.Length; i++)
            {
                attackCol[i].SetActive(false);
                Debug.Log("atkColOff");
            }
            attacking = false;
        }
    }

    public float range;
    public void VerifyPlayerDistance()
    {
        if (currentState != IaState.Dying || currentState != IaState.Stun)
        {
            CancelInvoke("VerifyPlayerDistance");
        }
        else if ((target.transform.position - transform.position).sqrMagnitude < range * range)
        {
            currentState = IaState.Follow;
            CancelInvoke("VerifyPlayerDistance");
        }
    }

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.8f);
        Instantiate(enDeadParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
