using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunAttack : MonoBehaviour
{
    public Image imageBar;
    public GameObject stunAttack;
    public Animator anim;

    public const int MANA_MAX = 100;

    private float manaAmount = 0;
    private float manaRegenAmount = 5f;
    private void Awake()//pega partes da UI e o ataque em si
    {
        stunAttack = GameObject.FindWithTag("StunAttack");
        anim = stunAttack.GetComponent<Animator>();
        imageBar = GameObject.Find("SpAtk Bar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()//começa com mana cheia
    {
        //player = GameObject.FindWithTag("Player");
        //anim = player.GetComponent<Animator>();
        manaAmount = 99;
    }

    // Update is called once per frame
    void Update()//enche mana e verifica quando o player aperta Q
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0f, MANA_MAX);

        imageBar.fillAmount = GetManaNormalized();

        if (Input.GetButtonDown("SpAttack"))
        {
            TrySpendMana(100);
        }

    }

    public void TrySpendMana(int amount)//chama o ataque, volta a mana pra 0
    {
        if (manaAmount >= amount)
        {
            anim.SetTrigger("StunAttack");
            manaAmount -= amount;
        }
    }

    public float GetManaNormalized()//sem isso o fillAmount n funciona
    {
        return manaAmount / MANA_MAX;
    }
}
