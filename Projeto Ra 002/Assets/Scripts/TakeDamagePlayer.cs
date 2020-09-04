using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamagePlayer : MonoBehaviour
{
    //public Animator anim;

    public GameObject lose;//canvas lose
    public bool iFrames = false;
    public float HP;
    public enum PlayerState
    {
        Still,
        Walk,
        Attack,
        Hurt,
        Dying,
        Dead,
    }
    public PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case PlayerState.Still:
                Still();
                break;
            case PlayerState.Walk:
                Walk();
                break;
            case PlayerState.Attack:
                Attack();
                break;
            case PlayerState.Hurt:
                Hurt();
                break;
            case PlayerState.Dying:
                Dying();
                break;
            case PlayerState.Dead:
                Dead();
                break;
        }
        //agent.SetDestination(target.transform.position);
    }

    void Still()
    {

    }

    void Walk()
    {
        //anim.SetBool("Attack", false);
    }

    void Attack()
    {

    }

    void Hurt()
    {
        //anim.SetTrigger("Hit");
        if (!iFrames)
        {
            currentState = PlayerState.Still;
        }
    }
    void Dying()
    {
        //destruir script que faz ele se mover?
        //anim.SetBool("Attack", false);
    }

    void Dead()
    {
        lose.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!iFrames && other.gameObject.tag == "EnemyShot")
        {
            if (HP > 0)
            {
                HP--;
                StartCoroutine(TakeDamage());

                currentState = PlayerState.Hurt;
                Destroy(other.gameObject);
            }
            else
            {
                currentState = PlayerState.Dead;//trocar pra dying
            }
        }
        else if (!iFrames && other.gameObject.tag == "Enemy")
        {
            if (HP > 0)
            {
                HP--;
                StartCoroutine(TakeDamage());

                currentState = PlayerState.Hurt;
            }
            else
            {
                currentState = PlayerState.Dead;//trocar pra dying
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

