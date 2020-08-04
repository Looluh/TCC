using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DisplayHP : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Health:" + player.GetComponent<TakeDamagePlayer>().hp.ToString();
        //Debug.Log(player.GetComponent("TakeDamagePlayer"));
    }
}
