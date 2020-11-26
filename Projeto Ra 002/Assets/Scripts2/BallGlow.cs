using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGlow : MonoBehaviour
{
    public Color frogC;
    public Color owlC;
    public Color dragonflyC;
    public Color hippoC;

    public ParticleSystem ballParSys;

    public Gradient defaultG;
    public Gradient frogG;
    public Gradient owlG;
    public Gradient dragonflyG;
    public Gradient hippoG;

    public Light ballLI;
    public Material ballMA;
    // Start is called before the first frame update
    public void Start()
    {
        ballMA = GetComponent<Renderer>().material;
        ballMA.EnableKeyword("_EMISSION");
        var col = ballParSys.colorOverLifetime;
        col.color = defaultG;

        ballMA.SetColor("_Color", Color.red);
        ballMA.SetColor("_EmissionColor", Color.red);
        ballLI.color = Color.red;

    }
    public void Green()//um metodo pra cada cor de porta
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

    public IEnumerator GreenCR()//uma corotina pra cada cor de porta - troca temporariamente a cor do ra (ballgod)
    {
        ballMA.EnableKeyword("_EMISSION");

        ballMA.SetColor("_Color", frogC);
        ballMA.SetColor("_EmissionColor", frogC);
        ballLI.color = frogC;

        var col = ballParSys.colorOverLifetime;
        col.color = frogG;

        yield return new WaitForSeconds(1f);
        Red();
    }
    public IEnumerator BrownCR()
    {
        ballMA.EnableKeyword("_EMISSION");

        ballMA.SetColor("_Color", owlC);
        ballMA.SetColor("_EmissionColor", owlC);
        ballLI.color = owlC;

        var col = ballParSys.colorOverLifetime;
        col.color = owlG;

        yield return new WaitForSeconds(1f);
        Red();
    }
    public IEnumerator PurpleCR()
    {
        ballMA.EnableKeyword("_EMISSION");

        ballMA.SetColor("_Color", dragonflyC);
        ballMA.SetColor("_EmissionColor", dragonflyC);
        ballLI.color = dragonflyC;

        var col = ballParSys.colorOverLifetime;
        col.color = dragonflyG;

        yield return new WaitForSeconds(1f);
        Red();
    }
    public IEnumerator AquaCR()
    {
        ballMA.EnableKeyword("_EMISSION");

        ballMA.SetColor("_Color", hippoC);
        ballMA.SetColor("_EmissionColor", hippoC);
        ballLI.color = hippoC;

        var col = ballParSys.colorOverLifetime;
        col.color = hippoG;

        yield return new WaitForSeconds(1f);
        Red();
    }
    public void Red()//volta a cor padrão
    {
        ballMA.EnableKeyword("_EMISSION");

        var col = ballParSys.colorOverLifetime;
        col.color = defaultG;

        ballMA.SetColor("_Color", Color.red);
        ballMA.SetColor("_EmissionColor", Color.red);
        ballLI.color = Color.red;
    }
}
