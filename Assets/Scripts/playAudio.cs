using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent <AudioSource>();
        audioSrc.loop = true;
        if(!audioSrc.isPlaying)
        {
            audioSrc.Play();
        }
    }
}
