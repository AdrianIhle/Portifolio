using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour {

    public AudioSource[] sounds;
    // Use this for initialization
    void Start () {
        sounds = GetComponentsInChildren<AudioSource>();
	}

    public void PlaySound(int soundNr)
    {
        PlaySound(sounds[soundNr]);
    }

    public void PauseSound(int sound)
    {
        sounds[sound].Pause();
    }
    public void UnpauseSound(int sound)
    {
        sounds[sound].UnPause();
    }



    public void PlaySound(AudioSource s)
    {
        StopAllSounds();
        s.Play();   
    }

    public void StopAllSounds()
    {
        foreach(AudioSource s in sounds)
        {
            s.Stop();
        }
    }

    public bool IsPlaying()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].isPlaying)
                return true;
        }
        return false;
    }

    public float GetClipLength(int sourceNr)
    {
        print("source name " + sounds[sourceNr].name);

        return sounds[sourceNr].clip.length;
    }
}
