using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamagePlayer : MonoBehaviour
{
    public float HP = 10;
    public bool iFrames;

    public GameObject plr;//não usado, vindo do enemy

    // Start is called before the first frame update
    void Start()
    {
        iFrames = false;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!iFrames && other.tag == "Enemy")
        {
            StartCoroutine(TakeDamage());
            HP--;
            //Destroy(other.gameObject);

        }

        if (HP <= 0)
        {
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = new Vector3(0, 1.5f, 13);
            gameObject.GetComponent<CharacterController>().enabled = true;
            HP = 10;
        }
    }

    public void Damage()
    {
        StartCoroutine(TakeDamage());
        HP--;
        //Destroy(col.gameObject);
        if (HP <= 0)
        {
            plr.GetComponent<IAControl>().enabled = false;
            Destroy(gameObject, 30);
        }

    }

    public IEnumerator TakeDamage()
    {
        iFrames = true;
        yield return new WaitForSeconds(3.0f);
        iFrames = false;
    }
}

