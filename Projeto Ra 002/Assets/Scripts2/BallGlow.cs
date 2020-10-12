using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGlow : MonoBehaviour
{
    public Color frogC;
    public Color owlC;
    public Color dragonflyC;
    public Color hippoC;

    public Light ballLI;
    public Material ballMA;
    // Start is called before the first frame update

    public void Green()
    {
        StopAllCoroutines();
        StartCoroutine(GreenCR());
    }

    public void Brown()
    {
        StopAllCoroutines();
        StartCoroutine(BrownCR());
    }
    public void Purple()
    {
        StopAllCoroutines();
        StartCoroutine(PurpleCR());
    }
    public void Aqua()
    {
        StopAllCoroutines();
        StartCoroutine(AquaCR());
    }

    public IEnumerator GreenCR()
    {
        //ballMA.SetColor("_Color", frogC);
        ballMA.SetColor("_EmissionColor", frogC);
        ballLI.color = frogC;
        yield return new WaitForSeconds(1f);
        Red();
    }
    public IEnumerator BrownCR()
    {
        ballMA.SetColor("_EmissionColor", owlC);
        ballLI.color = owlC;
        yield return new WaitForSeconds(1f);
        Red();
    }
    public IEnumerator PurpleCR()
    {
        ballMA.SetColor("_EmissionColor", dragonflyC);
        ballLI.color = dragonflyC;
        yield return new WaitForSeconds(1f);
        Red();
    }
    public IEnumerator AquaCR()
    {
        ballMA.SetColor("_EmissionColor", hippoC);
        ballLI.color = hippoC;
        yield return new WaitForSeconds(1f);
        Red();
    }
    public void Red()
    {
        ballMA.SetColor("_EmissionColor", Color.red);
        ballLI.color = Color.red;
    }
}
