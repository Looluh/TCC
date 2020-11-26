using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()//move a bala pra frente
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)//não colide com o jogador nem paredes invísíveis (collision matrix)
    {
            Destroy(gameObject);
        //if (!col.gameObject.CompareTag("Player"))
    }
}

