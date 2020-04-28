using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodShotAt : MonoBehaviour
{
    public bool ok1;
    public bool ok2;
    public bool ok3;
    public bool ok4;
    public bool ok5;
    public bool ok6;
    public bool ok7;
    public bool ok8;



    // Start is called before the first frame update
    void Start()
    {
        ok1 = false;
        ok2 = false;
        ok3 = false;
        ok4 = false;
        ok5 = false;
        ok6 = false;
        ok7 = false;
        ok8 = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Button1()
    {
        ok1 = false;

        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }
    }

    void Button2()
    {
        ok2 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }

    void Button3()
    {
        ok3 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }

    void Button4()
    {
        ok4 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }

    void Button5()
    {
        ok5 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }

    void Button6()
    {
        ok6 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }

    void Button7()
    {
        ok7 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }

    void Button8()
    {
        ok8 = false;
        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8)
        {
            Destroy(gameObject);
        }

    }
}
