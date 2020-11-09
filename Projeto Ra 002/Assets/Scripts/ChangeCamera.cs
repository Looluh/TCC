using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject[] currentCa;
    public GameObject[] changeToCa;
    public string wantedTag;

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
        if (other.gameObject.CompareTag(wantedTag))
        {
            for (int i = 0; i < changeToCa.Length; i++)
            {

                currentCa[i].gameObject.SetActive(false);
                changeToCa[i].gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
