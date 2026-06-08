using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null && s.source != null)
        {
            s.source.Play();

        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public float Length(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.clip.length;
    }
    public void SetVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
    }
    public float Volume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
       return s.source.volume;
    }
    public void SetPitch(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitch;
    }
}
