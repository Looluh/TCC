using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBrain : MonoBehaviour
{
    private static RespawnBrain instance;

    public Vector3 lastCheckpointPos;
    public float height;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
