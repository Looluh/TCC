using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource auds;
    public AudioClip clip;

    public void Start()
    {
        auds.PlayOneShot(clip, 1);
    }
}
