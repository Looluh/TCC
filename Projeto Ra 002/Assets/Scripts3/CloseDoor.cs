using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    //used to trap the player
    public GameObject door;
    public Animator doorAnim;
    public AudioSource doorAudS;
    public GameObject dustParticles;
    public AudioClip doorAudC;

    public bool done;
    // Start is called before the first frame update
    void Start()//pega componentes da porta
    {
        doorAnim = door.GetComponent<Animator>();
        doorAudS = door.GetComponent<AudioSource>();
        dustParticles = door.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)//detecta player no trigger
    {
        if (!done && other.gameObject.CompareTag("Player"))
        {
            done = true;
            StartCoroutine(DoorDust());
            doorAudS.PlayOneShot(doorAudC);
            doorAnim.SetBool("Aberto", false);
        }
    }

    public IEnumerator DoorDust()//particulas de poeira da porta
    {
        dustParticles.SetActive(true);

        yield return new WaitForSeconds(2f);

        dustParticles.SetActive(false);
    }

}
