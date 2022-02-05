using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGManager : MonoBehaviour
{
    public static AudioBGManager Instance;

    AudioSource audioBG;

    public AudioClip clickSfx;

    private void Awake()
    {
        Instance = this;
        audioBG = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip sfx)
    {
        audioBG.clip = sfx;
        audioBG.Play();
    }

    public void PlayClickSfx()
    {
        PlayClip(clickSfx);
    }
}
