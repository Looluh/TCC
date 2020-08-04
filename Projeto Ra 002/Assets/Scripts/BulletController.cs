using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.collider.CompareTag("Player") || !col.collider.CompareTag("Enemy") || !col.collider.CompareTag("ShotAt"))
        {
            Destroy(gameObject);
        }
    }
}

