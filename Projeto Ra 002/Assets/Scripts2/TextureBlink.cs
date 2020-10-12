using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureBlink : MonoBehaviour
{
    public Material mat;
    public Color gren;
    public Color redd;
    public Color colorNow;
    public Light li;
    public float emission;

    // Start is called before the first frame update
    void Start()
    {
        li = GetComponent<Light>();
        mat = GetComponent<Renderer>().material;
        gren = new Color(0.098f, 0.443f, 0f, 1);
        redd = new Color(1f, 0.0392f, 0f, 1);
        colorNow = gren;
    }

    // Update is called once per frame
    void Update()
    {
        emission = Mathf.PingPong(Time.time * 2, 1.5f);
        Color finalColor = colorNow * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        li.color = colorNow;
        colorNow = Color.Lerp(colorNow, gren, 1.2f * Time.deltaTime);
    }

}
