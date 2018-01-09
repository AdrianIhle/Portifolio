using UnityEngine;
using System.Collections;

public class ActivateEndScreen : MonoBehaviour {

	public GameObject EndScreen;

	void Start(){
		EndScreen.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D character){
		if (character.name == "character") {
			EndScreen.SetActive (true);
			Time.timeScale = 0f;
		}
	}

}
