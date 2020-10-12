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
    private void Awake()
    {
        stunAttack = GameObject.FindWithTag("StunAttack");
        anim = stunAttack.GetComponent<Animator>();
        imageBar = GameObject.Find("Bar").GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //anim = player.GetComponent<Animator>();
        manaAmount = 99;
    }

    // Update is called once per frame
    void Update()
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0f, MANA_MAX);

        imageBar.fillAmount = GetManaNormalized();

        if (Input.GetKeyDown(KeyCode.Q) )
        {
            TrySpendMana(100);
        }

    }


    //public Animator anim;

    public void TrySpendMana(int amount)
    {
        if (manaAmount >= amount)
        {
            anim.SetTrigger("StunAttack");
            manaAmount -= amount;
        }
    }

    public float GetManaNormalized()
    {
        return manaAmount / MANA_MAX;
    }
}
