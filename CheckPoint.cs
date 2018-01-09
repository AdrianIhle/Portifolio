using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D character){
		if (character.tag == "Player")
			character.GetComponent<controller> ().CurrentCheckPoint = this.gameObject.transform;
	}
}
