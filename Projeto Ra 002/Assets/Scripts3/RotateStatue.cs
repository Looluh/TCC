using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStatue : MonoBehaviour
{
    public GameObject objToRotate;
    public float speed;

    public bool[] done;

    public bool keyA;
    public bool keyB;

    public GameObject wall;
    public Animator wallAnim;

    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;
    public AudioClip doorAudC;
    public GameObject[] dustParticles;

    public GameObject raEyes;

    public GameObject[] currentCa;
    public GameObject[] changeToCa;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAnim[i] = doors[i].GetComponent<Animator>();
            doorAudS[i] = doors[i].GetComponent<AudioSource>();
            dustParticles[i] = doors[i].transform.GetChild(0).gameObject;
        }
        wallAnim = wall.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//raycast nas portas para abrí-las quando possível
    {
        RaycastHit hit;
        int layerMask = 1 << 15;
        //layerMask = ~layerMask;//inverte a mascara: afeta tudo exceto a mascara
        if (Physics.Raycast(raEyes.transform.position, raEyes.transform.forward * 75, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.DrawRay(raEyes.transform.position, raEyes.transform.forward * 100, Color.blue);
            //Debug.Log("Did Hit");
            if (!done[0] && hit.transform.gameObject == wall)
            {
                done[0] = true;

                wallAnim.SetBool("Down2", true);
            }

            else if (!done[1] && keyA && hit.transform.gameObject == doors[0])
            {
                done[1] = true;

                StartCoroutine(DoorDust(0));
                doorAudS[0].PlayOneShot(doorAudC);
                doorAnim[0].SetBool("Aberto", true);

            }

            else if (!done[2] && keyB && hit.transform.gameObject == doors[1])
            {
                done[2] = true;

                StartCoroutine(DoorDust(1));
                doorAudS[1].PlayOneShot(doorAudC);
                doorAnim[1].SetBool("Aberto", true);

            }

        }
        Debug.DrawRay(raEyes.transform.position, raEyes.transform.forward * 75, Color.red);

    }

    private void OnTriggerEnter(Collider other)//troca a câmera de volta
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < changeToCa.Length; i++)
            {
                currentCa[i].gameObject.SetActive(false);
                changeToCa[i].gameObject.SetActive(true);
            }
        }

    }

    private void OnTriggerStay(Collider other)//rotaciona a estátua, troca a camera
    {
        if (other.CompareTag("Player"))
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    for (int i = 0; i < changeToCa.Length; i++)
            //    {
            //        currentCa[i].gameObject.SetActive(false);
            //        changeToCa[i].gameObject.SetActive(true);
            //    }
            //}

            if (Input.GetButton("Interact"))
            {
                objToRotate.transform.Rotate(Vector3.up * speed * Time.deltaTime);
                //for (int i = 0; i < changeToCa.Length; i++)
                //{
                //    currentCa[i].gameObject.SetActive(false);
                //    changeToCa[i].gameObject.SetActive(true);
                //}
                //VerifyAngle();
            }

            //if (Input.GetKeyUp(KeyCode.E))
            //{
            //    for (int i = 0; i < changeToCa.Length; i++)
            //    {
            //        currentCa[i].gameObject.SetActive(true);
            //        changeToCa[i].gameObject.SetActive(false);
            //    }
            //
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            for (int i = 0; i < changeToCa.Length; i++)
            {
                currentCa[i].gameObject.SetActive(true);
                changeToCa[i].gameObject.SetActive(false);
            }
        }
    }

    public void VerifyAngle()//old, discarded, barely works
    {

        if (!done[0] && keyA && objToRotate.transform.eulerAngles.y >= 70 && objToRotate.transform.eulerAngles.y <= 80)
        {
            done[0] = true;

            StartCoroutine(DoorDust(0));
            doorAudS[0].PlayOneShot(doorAudC);
            doorAnim[0].SetBool("Aberto", true);
        }

        if (!done[1])
        {
            if (objToRotate.transform.eulerAngles.y >= 175 && objToRotate.transform.eulerAngles.y <= 180)
            {
                done[1] = true;
                wallAnim.SetBool("Down2", true);
            }
            else if (objToRotate.transform.eulerAngles.y >= -180 && objToRotate.transform.eulerAngles.y <= -175)
            {
                done[1] = true;
                wallAnim.SetBool("Down2", true);
            }
        }

        if (!done[2] && keyB && objToRotate.transform.eulerAngles.y >= -110)// && objToRotate.transform.eulerAngles.y <= -100)
        {
            done[2] = true;

            StartCoroutine(DoorDust(1));
            doorAudS[1].PlayOneShot(doorAudC);
            doorAnim[1].SetBool("Aberto", true);

        }
    }

    public IEnumerator DoorDust(int i)
    {
        dustParticles[i].SetActive(true);

        yield return new WaitForSeconds(2f);

        dustParticles[i].SetActive(false);
    }

}
