using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private AudioSource ac;
    private float musicVolume = 1f;
    void Start()
    {
        ac = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ac.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
}
