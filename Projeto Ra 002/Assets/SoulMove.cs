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
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SoulTarget");
        aimC = GetComponent<AimConstraint>();
        conS.sourceTransform = target.transform;
        conS.weight = 1;
        aimC.SetSource(0, conS);
        soulC = GameObject.FindGameObjectWithTag("SoulTarget").GetComponent<SoulCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);
        transform.Translate(transform.forward * moveSpeed);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("SoulTarget"))
        {
            soulC.Count();
            Destroy(gameObject);
        }
    }
}
