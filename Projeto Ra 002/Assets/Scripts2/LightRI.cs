using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRI : MonoBehaviour
{
    public Light li;
    //public float timer;
    public float minIntensity;
    public float maxIntensity;
    public float minRange;
    public float maxRange;
    public float random;
    public float randomTime;

    // Start is called before the first frame update
    void Start()
    {
        li = GetComponent<Light>();
        random = Random.Range(0.0f, 65535.0f); 
        randomTime = Random.Range(4f, 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;
        li.intensity += oscillate(timer, 10, 0.01f);
        li.range = Mathf.PingPong(Time.time, 8); oscillate(timer, 10, 0.01f);

        float oscillate(float time, float speed, float scale)
        {
            return Mathf.Cos(time * speed / Mathf.PI) * scale;
        }*/
        float noise = Mathf.PerlinNoise(random, Time.time * randomTime/1.5f);
        li.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        li.range = Mathf.Lerp(minRange, maxRange, noise);
    }
}
