﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sounds[] drumClips;
    public Sounds[] bassClips;
    public Sounds[] guitarClips;


	// Use this for initialization
	void Awake () {
        foreach (Sounds s in drumClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        foreach (Sounds s in bassClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        foreach (Sounds s in guitarClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }


    }
	public void PlayDrums(string name)
    {
        Sounds s = Array.Find(drumClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Error music name:" + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayBass(string name)
    {
        Sounds s = Array.Find(bassClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Error music name:" + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayGuitar(string name)
    {
        Sounds s = Array.Find(guitarClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Error music name:" + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void Pause()
    {
        Sounds sG = Array.Find(guitarClips, sound => sound.name == name);
        Sounds sB = Array.Find(bassClips, sound => sound.name == name);
        Sounds sD = Array.Find(drumClips, sound => sound.name == name);
        sG.source.Pause();
        sB.source.Pause();
        sD.source.Pause();
    }

}
