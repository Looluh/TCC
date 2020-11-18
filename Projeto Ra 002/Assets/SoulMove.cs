using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SoulMove : MonoBehaviour
{
    public GameObject target;
    public AimConstraint aimC;
    public ConstraintSource conS;

    public SoulCounter soulC;
    public float moveSpeed;
    public ParticleSystem soulParSys;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SoulTarget");//define o alvo
        aimC = GetComponent<AimConstraint>();
        conS.sourceTransform = target.transform;//define o alvo como fonte do constraint
        conS.weight = 1;//peso do constraint
        aimC.SetSource(0, conS);//adiciona o constraint
        soulC = GameObject.FindGameObjectWithTag("SoulTarget").GetComponent<SoulCounter>();
        soulParSys = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()//move a alma na direção do alvo
    {
        //transform.LookAt(target);
        transform.Translate(transform.forward * moveSpeed);
    }

    private void OnCollisionEnter(Collision col)//destrói a alma e faz a contagem
    {
        if (col.gameObject.CompareTag("SoulTarget"))
        {
            soulParSys.Stop();
            GetComponent<Renderer>().enabled = false;
            soulC.Count();
            Destroy(gameObject, 2);
        }
    }
}
