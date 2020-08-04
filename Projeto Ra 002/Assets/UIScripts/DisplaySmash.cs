using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySmash : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = button.GetComponent<SmashButton>().smashNo.ToString();
        if (button.GetComponent<SmashButton>().smashNo <= 0)
        {
            Destroy(gameObject);
        }
    }
}
