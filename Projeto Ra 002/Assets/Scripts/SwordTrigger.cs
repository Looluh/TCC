using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    public bool iFrames = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !iFrames)
        {
            other.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
            StartCoroutine(TakeDamage());
        }
    }
    public IEnumerator TakeDamage()
    {
        iFrames = true;
        yield return new WaitForSeconds(1.0f);
        iFrames = false;
    }


}
