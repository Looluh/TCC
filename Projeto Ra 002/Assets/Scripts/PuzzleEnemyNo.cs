using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnemyNo : MonoBehaviour
{
    public GameObject activated;
    public GameObject deactivated;

    [SerializeField]
    public float enemyNoWanted;

    public float enemyNoNow = 0;
    public GameObject enemyToCount;

    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;
    public bool on;

    public bool done = false;

    public AudioClip audC;

    public GameObject[] dustParticles;

    // Start is called before the first frame update
    void Start()//componentes das portas
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAnim[i] = doors[i].GetComponent<Animator>();
            doorAudS[i] = doors[i].GetComponent<AudioSource>();
            dustParticles[i] = doors[i].transform.GetChild(0).gameObject;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)//detecta inimigo entrando e conta, verifica se tem a quantidade certa
    {
        if (other.gameObject.CompareTag("Enemy") && !done)
        {
            Debug.Log("Entrou");
            enemyNoNow++;

            if (enemyNoNow == enemyNoWanted)
            {
                Debug.Log("Mesmo número");
                done = true;
                if (on)
                {
                    Off();
                }
                else if (!on)
                {
                    On();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)//detecta inimigo saindo e desconta
    {
        if (other.gameObject.CompareTag("Enemy") && !done)
        {
            Debug.Log("Saiu");
            enemyNoNow--;
        }
    }

    void On()//abre as portas, toca som, ativa particulas e instancia mensagem
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", true);
        }
        //on = true;
        StartCoroutine(DoorDust());


        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    void Off()//fecha as portas, toca som, ativa particulas e instancia mensagem
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", false);
        }
        //on = false;
        StartCoroutine(DoorDust());


        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    public IEnumerator DoorDust()//ativa particulas e espera pra desativar
    {
        for (int i = 0; i < doors.Length; i++)
        {
            dustParticles[i].SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < doors.Length; i++)
        {
            dustParticles[i].SetActive(false);
        }
    }


}

