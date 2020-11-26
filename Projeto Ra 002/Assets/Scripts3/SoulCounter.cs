using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SoulCounter : MonoBehaviour
{
    public GameObject activated;
    public GameObject deactivated;

    public int soulWanted;
    public int soulNow;

    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;
    public bool on;

    public bool done = false;

    public AudioClip audC;

    public GameObject objGoUp;
    public Animator objGoUpAnim;

    public GameObject[] dustParticles;

    // Start is called before the first frame update
    void Start()//pega varios componentes das portas + animator da chave
    {
        objGoUpAnim = objGoUp.GetComponent<Animator>();
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

    public void Count()//adciona ao contador de almas e verifica se é a quantidade certa
    {
        soulNow++;

        if (soulNow >= soulWanted && !done)
        {
            done = true;
            if (on)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }

    void On()//abre as portas, toca som, ativa particulas e instancia mensagem -- tambem faz a chave aparecer (ou a saída)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", true);
        }
        StartCoroutine(DoorDust());

        objGoUpAnim.SetBool("Up", true);
        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    void Off()//fecha as portas, toca som, ativa particulas e instancia mensagem
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", false);
        }
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
