using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioControl : AudioObject {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySuccess()
    {
        PlaySound(0);
    }
    
    public void PlayAchievementGet()
    {
        sounds[1].Play();
    }
}
