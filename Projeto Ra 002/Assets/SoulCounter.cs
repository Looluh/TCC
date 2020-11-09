using UnityEngine;

public class SoulCounter : MonoBehaviour
{
    public GameObject activated;
    public GameObject deactivated;

    public int soulWanted;
    public int soulNow;

    public GameObject[] doors;
    public Animator[] doorAnim;
    public AudioSource[] doorAudS;
    public bool on;

    public bool done = false;

    public AudioClip audC;

    public GameObject objGoUp;
    public Animator objGoUpAnim;
    // Start is called before the first frame update
    void Start()
    {
        objGoUpAnim = objGoUp.GetComponent<Animator>();
        for (int i = 0; i < doors.Length; i++)
        {
            doorAnim[i] = doors[i].GetComponent<Animator>();
            doorAudS[i] = doors[i].GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Count()
    {
        soulNow++;

        if (soulNow >= soulWanted && !done)
        {
            done = true;
            if (on)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }

    void On()//abre
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", true);
        }
        objGoUpAnim.SetBool("Up", true);
        Instantiate(deactivated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), deactivated.transform.rotation);
    }

    void Off()//fecha
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doorAudS[i].PlayOneShot(audC);
            doorAnim[i].SetBool("Aberto", false);
        }
        Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
    }
}
