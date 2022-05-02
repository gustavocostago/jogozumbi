using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource myAudio;
    public static AudioSource instacia;
    void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        instacia = myAudio;
    }
}
