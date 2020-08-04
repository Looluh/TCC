using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamagePlayer : MonoBehaviour
{
    public float hp = 10;
    public bool iFrames;
    public GameObject lose;

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
            hp--;
            //Destroy(other.gameObject);

        }

        if (hp <= 0)
        {
            /*
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = new Vector3(0, 1.5f, 13);
            gameObject.GetComponent<CharacterController>().enabled = true;
            HP = 10;*/
            lose.SetActive(true);
        }
    }

    public void Damage()
    {
        StartCoroutine(TakeDamage());
        hp--;
        //Destroy(col.gameObject);
        if (hp <= 0)
        {
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

