using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    Vector3 playeraxis;
    public CharacterController cctrl;

    public Animator UIDamage;
    public Animator anim;

    public int noOfClicks;
    public bool canClick;

    public GameObject swordCol1;
    public GameObject swordCol2;

    public GameObject UIDead;
    public enum PlayerState
    {
        Idle,
        Run,
        Walk,
        Hurt,
        Canalization,
        Victory,
        Dead,
    }
    public PlayerState currentState;

    public float timerCombo;
    AnimationClip[] clips;
    //public bool groundedPlayer;
    //public Vector3 playerVelocity;
    //public float gravityValue = -9;

    // Start is called before the first frame update

    public Camera cam;

    public GameObject canvasLose;
    void Start()
    {
        anim = GetComponent<Animator>();
        clips = anim.runtimeAnimatorController.animationClips;

        noOfClicks = 0;
        canClick = true;
        swordCol1 = GameObject.Find("KhoCol1");
        swordCol2 = GameObject.Find("KhoCol2");
        currentState = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)//maquina de estados do jogador
        {
            case PlayerState.Idle:
                Idle();
                break;
            case PlayerState.Run:
                Run();
                break;
            case PlayerState.Walk:
                Walk();
                break;
            case PlayerState.Hurt:
                Hurt();
                break;
            case PlayerState.Canalization:
                Canalization();
                break;
            case PlayerState.Victory:
                Victory();
                break;
            case PlayerState.Dead:
                Dead();
                break;
        }
        //Vector3 movimentoGlobal = transform.TransformDirection(playeraxis * playerSpeed);

        //método do professor
        /*groundedPlayer = cctrl.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cctrl.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        cctrl.Move(playerVelocity * Time.deltaTime);*/


        //novo, teste de direção do massa
        if (currentState != PlayerState.Dead && currentState != PlayerState.Victory)//inputs de movimentação e ataque
        {
            playeraxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            cctrl.SimpleMove(playeraxis * playerSpeed);//Move?

            Vector3 globalMov = cam.transform.TransformDirection(new Vector3(playeraxis.x, 0, playeraxis.z));
            globalMov = new Vector3(globalMov.x, 0, globalMov.z);

            //limita o exagero do input
            if (playeraxis.magnitude > 1)
                playeraxis.Normalize();

            /*Vector3 movfinal = (globalMov).normalized * playeraxis.magnitude * playerSpeed;
            movfinal += new Vector3(0, -9, 0);                                                       //movimentação do professor
            cctrl.Move(movfinal);*/

            //calcula quantos graus o personagem deve virar
            float radtogo = Vector3.Dot(transform.right, globalMov.normalized) * 50;//20 é a velo q ele vira

            //evita andar de re
            if ((transform.forward - globalMov.normalized).magnitude > 1)
            {
                transform.Rotate(0, 1, 0);
            }
            transform.Rotate(0, radtogo, 0);

            /*if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, -45, 0);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 225, 0);
            }*/
            if (Input.GetMouseButtonDown(0) && noOfClicks < 3)
            {
                swordCol1.SetActive(true);
                swordCol2.SetActive(true);
                ComboStarter(); //combo
            }

            if (timerCombo <= 0)
            {
                swordCol1.SetActive(false);
                swordCol2.SetActive(false);
                ResetCombo();
            }
            else
            {
                timerCombo -= Time.deltaTime;        //if (timerCombo > 0)
            }
        }
    }

    void Idle()
    {
        if (cctrl.velocity.magnitude > 0.1f)
        {
            currentState = PlayerState.Run;
        }
    }
    void Run()
    {
        anim.SetFloat("Velocity", cctrl.velocity.magnitude);
        if (cctrl.velocity.magnitude < 0.1f)
        {
            currentState = PlayerState.Idle;
        }
    }
    void Walk()//talvez
    {

    }

    void Hurt()
    {
        anim.SetTrigger("Hurt");
        currentState = PlayerState.Idle;
        UIDamage.SetTrigger("Play");
    }

    void Canalization()
    {
        anim.SetTrigger("Canalization");
        currentState = PlayerState.Idle;
    }
    public bool win = false;//doesnt repeat animation
    void Victory()
    {
        if (!win)
        {
            anim.SetTrigger("Victory");
            win = true;
        }
    }

    void Dead()
    {
        if (!iFrames)
        {
            UIDamage.SetTrigger("Play");
            anim.SetTrigger("Dead");
            iFrames = true;

            StartCoroutine(Die());
        }
    }

    #region TakeDamagePlayer
    public bool iFrames = false;
    public float HP;
    void OnTriggerEnter(Collider other)
    {
        if (!iFrames && other.gameObject.CompareTag("EnemyShot"))
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
        else if (!iFrames && other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("attackCol") && !iFrames)
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

    public IEnumerator TakeDamage()//frames de invincibilidade após levar dano
    {
        iFrames = true;
        yield return new WaitForSeconds(5f);
        iFrames = false;
    }

    public IEnumerator Die()//chamado ao morrer, dá um tempo antes de aparecer a tela de derrota
    {
        yield return new WaitForSeconds(3f);
        canvasLose.SetActive(true);
    }
    #endregion

    #region Combo
    void ComboStarter()//começa o combo
    {
        if (canClick)
        {
            noOfClicks++;
            //timerCombo += 1f;
            if (noOfClicks == 1)
            {
                timerCombo = clips[2].length / 4;
            }
            else if (noOfClicks == 2)
            {
                timerCombo += clips[1].length / 3.5f;
            }
            else if (noOfClicks == 3)
            {
                timerCombo += clips[3].length / 4;
            }
            else if (noOfClicks > 3 || noOfClicks == 0)
            {
                canClick = true;
            }
            //if (timerCombo>3)
            //{
            //    timerCombo = 2.3f;
            //}
            //clips.
        }

        /*if (noOfClicks == 1)
        {
            anim.SetInteger("Attack", 1);
        }*/
        anim.SetInteger("Attack", noOfClicks);
        //Invoke("ResetCombo", 1);
        canClick = false;
        //anim.t
    }

    void ResetCombo()//reinicia o combo
    {
        anim.SetInteger("Attack", 0);
        noOfClicks = 0;
        timerCombo = 0;
        canClick = true;
    }

    public void ComboCheck()//continua o combo, chamado no meio das animações de ataque
    {

        canClick = true;
        /*//noOfClicks = 0;
        //anim.SetInteger("Attack", noOfClicks);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque") || anim.GetCurrentAnimatorStateInfo(0).IsName("AtaqueRun") && noOfClicks == 1)
        {//If the first animation is still playing and only 1 click has happened, return to idle
            anim.SetInteger("Attack", 0);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque") || anim.GetCurrentAnimatorStateInfo(0).IsName("AtaqueRun") && noOfClicks >= 2)
        {//If the first animation is still playing and at least 2 clicks have happened, continue the combo          
            anim.SetInteger("Attack", 2);
            canClick = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque2Run") && noOfClicks == 2)
        {  //If the second animation is still playing and only 2 clicks have happened, return to idle         
            anim.SetInteger("Attack", 0);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque2Run") && noOfClicks >= 3)
        {  //If the second animation is still playing and at least 3 clicks have happened, continue the combo         
            anim.SetInteger("Attack", 3);
            canClick = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque3") || anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque3Run"))
        { //Since this is the third and last animation, return to idle          
            anim.SetInteger("Attack", 0);
            canClick = true;
            noOfClicks = 0;
        }*/
    }
    #endregion
}
