using UnityEngine;
using System.Collections;

public class TriggeredStone : MonoBehaviour {

	public GameObject Rock;

	void OnTriggerEnter2D(Collider2D character){
		if (character.tag == "Player") {
			Rock.SetActive (false);
		}
	}
}
