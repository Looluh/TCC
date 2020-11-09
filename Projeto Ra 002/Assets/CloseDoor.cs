using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;
    public AudioSource doorAudS;
    public GameObject dustParticles;
    public AudioClip doorAudC;

    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
        doorAudS = door.GetComponent<AudioSource>();
        dustParticles = door.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!done && other.gameObject.CompareTag("Player"))
        {
            done = true;
            StartCoroutine(DoorDust());
            doorAudS.PlayOneShot(doorAudC);
            doorAnim.SetBool("Aberto", false);
        }
    }

    public IEnumerator DoorDust()
    {
        dustParticles.SetActive(true);

        yield return new WaitForSeconds(2f);

        dustParticles.SetActive(false);
    }

}
