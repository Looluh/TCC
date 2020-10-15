using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityStandardAssets.Utility;

public class RespawnBrain : MonoBehaviour
{
    private static RespawnBrain instance;

    public Vector3 lastCheckpointPos;

    public float height;
    public float volume;
    public AudioMixer audioMix;

    //public SmoothFollow cameraScript;

    void Awake()
    {
        height = 10;
        volume = 0;

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

    private void Start()
    {
        audioMix.SetFloat("Volume", volume);
    }
}
