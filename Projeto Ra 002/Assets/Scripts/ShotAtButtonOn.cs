using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtButtonOn : MonoBehaviour
{
    //começa desligado e aí liga
    public GameObject activated;
    public Animator[] anim;
    public bool done = false;

    public BallGlow balGlo;
    public enum ColorGlow
    {
        Frog,
        Owl,
        Dragonfly,
        Hippo,
    }
    public ColorGlow currColorGlow;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Shot") && !done)
        {
            switch (currColorGlow)
            {
                case ColorGlow.Frog:
                    balGlo.Green();
                    break;
                case ColorGlow.Owl:
                    balGlo.Brown();
                    break;
                case ColorGlow.Dragonfly:
                    balGlo.Purple();
                    break;
                case ColorGlow.Hippo:
                    balGlo.Aqua();
                    break;
            }

            for (int i = 0; i < anim.Length; i++)
            {
                anim[i].SetBool("Aberto", false);
            }
            done = true;
            Instantiate(activated, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), activated.transform.rotation);
        }
    }
}

