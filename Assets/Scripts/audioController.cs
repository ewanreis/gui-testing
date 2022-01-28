using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class audioController : MonoBehaviour
{
    AudioSource audioSource2;
    public AudioClip[] audioClipArray;
    void Start() {
        audioSource2 = GetComponent<AudioSource>();
    }
    public void Play(int clip)
    {
        audioSource2.PlayOneShot(audioClipArray[clip], 0.7f);
    }
}
