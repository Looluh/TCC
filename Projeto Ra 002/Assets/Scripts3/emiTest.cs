using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emiTest : MonoBehaviour
{
    public Light glowL;
    public Material glowM;

    public Color frogC;
    public Color owlC;
    public Color dragonflyC;
    public Color hippoC;

    public enum ColorGlow
    {
        Frog,
        Owl,
        Dragonfly,
        Hippo,
    }
    public ColorGlow currColorGlow;

    // Start is called before the first frame update
    void Start()
    {
        glowM = gameObject.GetComponent<Renderer>().material;
        glowM.EnableKeyword("_EMISSION");

        print(glowM);
        switch (currColorGlow)
        {
            case ColorGlow.Frog:
                glowM.SetColor("_Emission", frogC);
                break;
            case ColorGlow.Owl:
                glowM.SetColor("_Emission", owlC);
                break;
            case ColorGlow.Dragonfly:
                glowM.SetColor("_Emission", dragonflyC);
                break;
            case ColorGlow.Hippo:
                glowM.SetColor("_Emission", hippoC);
                break;
        }
        glowM.SetColor("_EmissionColor", frogC);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
