using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStop : MonoBehaviour
{
    public GameObject platform;
    public Animator platAnim;
    public Animator plat2Anim;

    public bool stopped;
    // Start is called before the first frame update
    void Start()
    {
        platAnim = platform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!stopped && other.gameObject.CompareTag("Shot"))
        {
            platAnim.speed = 0;
            plat2Anim.speed = 0;
            stopped = true;
        }
        else if (stopped && other.gameObject.CompareTag("Shot"))
        {
            platAnim.speed = 1;
            plat2Anim.speed = 1;
            stopped = false;
        }
    }
}
