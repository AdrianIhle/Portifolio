using UnityEngine;
using System.Collections;
// plays death audio
public class playerAudio : MonoBehaviour {

	PlayerDeath PD;
	AudioSource source;
	// Use this for initialization
	void Start () {
		PD = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerDeath> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (PD.dead)
		if (!source.isPlaying)
			source.PlayDelayed (1f);
	
	}
}
