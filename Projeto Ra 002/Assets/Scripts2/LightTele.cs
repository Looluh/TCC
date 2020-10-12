using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LightTele : MonoBehaviour
{
    private float currCountdownValueOn;
    private float currCountdownValueOff;
    private bool on = false;

    public Light midLI;
    public VideoPlayer midVI;
    public AudioSource midAUD;

    public Light[] li;
    private Light tempLI;
    public VideoPlayer[] vi;
    private VideoPlayer tempVI;
    public AudioSource[] aud;
    private AudioSource tempAUD;

    public bool frog;
    public bool owl;
    public bool dragonfly;
    public bool hippo;

    public Color frogC;
    public Color owlC;
    public Color dragonflyC;
    public Color hippoC;

    public AudioClip auC;
    // Start is called before the first frame update
    void Start()
    {
        if (frog)
        {
            midLI.color = frogC;
            for (int i = 0; i < li.Length; i++)
            {
                li[i].color = frogC;
            }
        }
        else if (owl)
        {
            midLI.color = owlC;
            for (int i = 0; i < li.Length; i++)
            {
                li[i].color = owlC;
            }
        }
        else if (dragonfly)
        {
            midLI.color = dragonflyC;
            for (int i = 0; i < li.Length; i++)
            {
                li[i].color = dragonflyC;
            }
        }
        else if (hippo)
        {
            midLI.color = hippoC;
            for (int i = 0; i < li.Length; i++)
            {
                li[i].color = hippoC;
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!on)
            StartCoroutine(LightOnCountdown());
    }
    public void Shuffle()
    {
        for (int i = 0; i < li.Length - 1; i++)
        {
            int rnd = Random.Range(i, li.Length);
            tempLI = li[rnd];
            tempVI = vi[rnd];
            tempAUD = aud[rnd];
            li[rnd] = li[i];
            vi[rnd] = vi[i];
            aud[rnd] = aud[i];
            li[i] = tempLI;
            vi[i] = tempVI;
            aud[i] = tempAUD;
        }

        /*for (int i = 0; i < vi.Length - 1; i++)
        {
            int rnd = Random.Range(i, vi.Length);
            tempVI = vi[rnd];
            vi[rnd] = vi[i];
            vi[i] = tempVI;
        }*/

    }
    public IEnumerator LightOnCountdown(float countdownValueOn = 10)
    {
        on = true;
        Shuffle();
        currCountdownValueOn = countdownValueOn;

        midVI.enabled = true;
        midLI.enabled = true;
        midAUD.PlayOneShot(auC);

        while (currCountdownValueOn > 0)
        {
            Debug.Log("LightCountdown: " + currCountdownValueOn);
            yield return new WaitForSeconds(0.05f);
            currCountdownValueOn--;

            if (currCountdownValueOn == 8)
            {
                vi[0].enabled = true;
                li[0].enabled = true;
                aud[0].PlayOneShot(auC);
            }
            else if (currCountdownValueOn == 6)
            {
                vi[1].enabled = true;
                li[1].enabled = true;
                aud[1].PlayOneShot(auC);
            }
            else if (currCountdownValueOn == 4)
            {
                vi[2].enabled = true;
                li[2].enabled = true;
                aud[2].PlayOneShot(auC);
            }
            else if (currCountdownValueOn == 2)
            {
                vi[3].enabled = true;
                li[3].enabled = true;
                aud[3].PlayOneShot(auC);
                StartCoroutine(LightOffCountdown());
            }


        }
    }
    public IEnumerator LightOffCountdown(float countdownValueOff = 10)
    {
        //Shuffle();
        currCountdownValueOff = countdownValueOff;
        while (currCountdownValueOff > 0)
        {
            Debug.Log("LightCountdown: " + currCountdownValueOff);
            yield return new WaitForSeconds(1.0f);
            currCountdownValueOff--;

            if (currCountdownValueOff == 8)
            {
                vi[0].enabled = false;
                li[0].enabled = false;
                aud[0].PlayOneShot(auC);
            }
            else if (currCountdownValueOff == 6)
            {
                vi[1].enabled = false;
                li[1].enabled = false;
                aud[1].PlayOneShot(auC);
            }
            else if (currCountdownValueOff == 4)
            {
                vi[2].enabled = false;
                li[2].enabled = false;
                aud[2].PlayOneShot(auC);
            }
            else if (currCountdownValueOff == 2)
            {
                vi[3].enabled = false;
                li[3].enabled = false;
                aud[3].PlayOneShot(auC);
            }
        }

        midVI.enabled = false;
        midLI.enabled = false;
        midAUD.PlayOneShot(auC);
        on = false;

    }
}
