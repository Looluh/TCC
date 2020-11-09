using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SoulMove1 : MonoBehaviour
{
    public GameObject target;
    public AimConstraint aimC;
    public ConstraintSource conS;

    public SoulCounter soulC;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SoulTarget1");
        aimC = GetComponent<AimConstraint>();
        conS.sourceTransform = target.transform;
        conS.weight = 1;
        aimC.SetSource(0, conS);
        soulC = GameObject.FindGameObjectWithTag("SoulTarget1").GetComponent<SoulCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);
        transform.Translate(transform.forward * moveSpeed);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("SoulTarget1"))
        {
            soulC.Count();
            Destroy(gameObject);
        }
    }
}
