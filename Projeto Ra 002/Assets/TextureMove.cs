using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMove : MonoBehaviour
{
    public Renderer rend;
    public Texture[] tex;
    public Texture tex1;
    public Texture tex2;
    public Texture tex3;
    public Vector2[] displacement;
    public string[] texNo;
    // Start is called before the first frame update
    void Start()
    {
        List<string> list = new List<string>();
        //list.Add("_Tex1");

        rend = GetComponent<Renderer>();
        tex1 = rend.material.GetTexture("_Tex1");
        tex2 = rend.material.GetTexture("_Tex2");
        tex3 = rend.material.GetTexture("_Tex3");
        //displacement.x = Random.Range(0.1f, 0.15f);
        //displacement.y = Random.Range(0.1f, 0.15f);

        for (int i = 0; i < displacement.Length; i++)
        {
            list.Add("_Tex" + i) ;
            //tex[i] = rend.material.GetTexture("_Tex" + i);
            displacement[i].x = Random.Range(-0.15f, 0.15f);
            displacement[i].y = Random.Range(-0.15f, 0.15f);
        }
        texNo = list.ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        //rend.material.SetTextureOffset("_Tex1", new Vector2(1, 0));
        //rend.material.SetTextureOffset("_Tex1", new Vector2(Time.time * 0.01f, 0));
        //rend.material.SetTextureOffset("_Tex1", new Vector2(Time.time * displacement[0].x, Time.time * displacement[0].y));
        //rend.material.SetTextureOffset("_Tex2", new Vector2(Time.time * displacement[1].x, Time.time * displacement[1].y));
        //rend.material.SetTextureOffset("_Tex3", new Vector2(Time.time * displacement[2].x, Time.time * displacement[2].y));
        for (int i = 0; i < displacement.Length; i++)
        {
            rend.material.SetTextureOffset(texNo[i], new Vector2(Time.time * displacement[i].x, Time.time * displacement[i].y));
            if (i == displacement.Length)
                i = 0;
        }
    }
}
