using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DisplayHP : MonoBehaviour
{
    public GameObject player;

    public Image imageBar;

    public const float HP_MAX = 100;

    public float hp;

    public PlayerController playerCon;
    // Start is called before the first frame update
    void Start()//player e barra de hp
    {
        player = GameObject.FindGameObjectWithTag("Player");
        imageBar = GameObject.Find("HP Bar").GetComponent<Image>();
        //playerCon = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()//sempre verifica a vida do player e altera a barra
    {
        //GetComponent<TextMeshProUGUI>().text = "Health:" + player.GetComponent<PlayerController>().HP.ToString();//velha HUD
        //Debug.Log(player.GetComponent("TakeDamagePlayer"));
        hp = playerCon.HP;

        imageBar.fillAmount = GetHPNormalized();
    }

    public float GetHPNormalized()//sem isso o fillAmount n funciona
    {
        return hp / HP_MAX;
    }

}
