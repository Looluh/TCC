using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordButton : MonoBehaviour
{
    public float smashNo;

    public GameObject activated;
    public GameObject deactivated;
    public Animator[] anim;

    public bool waiting = false;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword") && !waiting)
        {
            smashNo--;
            StartCoroutine(Wait());
            if (smashNo == 0)
            {
                if (on)
                {
                    for (int i = 0; i < anim.Length; i++)
                    {
                        anim[i].SetBool("Aberto", true);
                    }

                    Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
                }

                else if (!on)
                {
                    for (int i = 0; i < anim.Length; i++)
                    {
                        anim[i].SetBool("Aberto", false);
                    }

                    Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
                }
            }
        }
    }

    public IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(1.0f);
        waiting = false;
    }
}
