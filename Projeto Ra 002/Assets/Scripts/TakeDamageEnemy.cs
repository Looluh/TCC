using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnemy : MonoBehaviour
{
    public float HP = 3;
    public bool iFrames;

    public GameObject enm;

    // Start is called before the first frame update
    void Start()
    {
        iFrames = false;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (!iFrames && col.collider.tag == "Shot" || col.collider.tag == "Sword")
        {
            StartCoroutine(TakeDamage());
            HP--;
            Destroy(col.gameObject);

        }

        if (HP <= 0)
        {
            enm.GetComponent<IAControl>().enabled = false;
            Destroy(gameObject, 3);
        }
    }

    public void Damage()
    {
        StartCoroutine(TakeDamage());
        HP--;
        //Destroy(col.gameObject);
        if (HP <= 0)
        {
            enm.GetComponent<IAControl>().enabled = false;
            Destroy(gameObject, 3);
        }

    }

    public IEnumerator TakeDamage()
    {
        iFrames = true;
        yield return new WaitForSeconds(0.5f);
        iFrames = false;
    }
}

