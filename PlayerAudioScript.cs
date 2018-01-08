using UnityEngine;
using System.Collections;
// sound played by player game object
public class PlayerAudioScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound (string soundRoot, string soundObject, bool play)
	{
		GameObject soundParent;
		GameObject soundRootObject;
		GameObject sound;
		soundParent = GameObject.FindGameObjectWithTag ("sfxAudio");
            //can be replaced by PlayOneShot()
		if (play) {
			if (soundRoot == "Player") {
				soundRootObject = soundParent.transform.FindChild ("Player").gameObject;
				if (soundObject == "Attack") {
					sound = soundRootObject.transform.FindChild ("AttackOne").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("Attack sound");
				}
				if (soundObject == "Balade") {
					sound = soundRootObject.transform.FindChild ("Balade").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("Gentle Lute");
                
				}
                if (soundObject == "PlayLute")
                {
                    sound = soundRootObject.transform.FindChild("PlayLute").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }

                if (soundObject == "Hurt") {
					sound = soundRootObject.transform.FindChild ("HurtOne").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("hurt");
				}
				if (soundObject == "MetalLute") {
					sound = soundRootObject.transform.FindChild ("MetalLute").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("Harsh Lute");
				}
				if (soundObject == "SwordAttack") {
					sound = soundRootObject.transform.FindChild ("SwordAttack").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("Sword sound");
				}
				if (soundObject == "Tada") {
					sound = soundRootObject.transform.FindChild ("TadaOne").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("Tada");
				}
				if (soundObject == "Triumph") {
					sound = soundRootObject.transform.FindChild ("TriumphOne").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
					Debug.Log ("Triumph");
				}
			}





			play = false;
		}
	}
}
