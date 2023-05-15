using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource musicSource, effectsSource;
    static public bool isCalling;

    private void Start()
    {
        if (!isCalling)
        {
            DontDestroyOnLoad(this);
            isCalling = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
}
