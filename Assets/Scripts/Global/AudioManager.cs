using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour, IService
{
    [SerializeField] private Sound[] sounds;


    public void Setup()
    {
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
        }
    }

    public void Play(string name)
    {
        var s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        var s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Stop();
    }
}
[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip clip;
    public bool Loop;
    [Range(0, 1f)]
    public float volume;

    [Range(0.03f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
