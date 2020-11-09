using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternButton : MonoBehaviour
{
    public bool on;

    public GameObject activated;
    public GameObject deactivated;
    public GameObject player;
    public bool ok = true;


    public AudioSource sparkAS;
    public AudioClip sparkAC;

    public PatternMaster1 patMast;

    public Animator patAnim;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!on && ok)
                {
                    On();
                    StartCoroutine(OkCheck());
                }
                else if (on && ok)
                {
                    Off();
                    StartCoroutine(OkCheck());
                }
            }
        }
    }

    void On()
    {
        on = true;
        patAnim.SetBool("Down", true);
        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }

    void Off()
    {
        on = false;
        patAnim.SetBool("Down", false);
        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    public IEnumerator OkCheck()
    {
        ok = false;
        patMast.VerifyPattern();


        sparkAS.PlayOneShot(sparkAC);

        yield return new WaitForSeconds(1.2f);

        ok = true;
    }
}

