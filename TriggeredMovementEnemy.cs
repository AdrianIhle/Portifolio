using UnityEngine;
using System.Collections;

public class TriggeredMovementEnemy : MonoBehaviour {

	public GameObject Enemy;

	void Start() {
		Enemy.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D character){
		if (character.tag == "Player") {
			Enemy.SetActive (true);
		}
	}
}
