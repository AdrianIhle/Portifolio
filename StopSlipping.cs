using UnityEngine;
using System.Collections;

public class StopSlipping : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
		//	if (Input.anyKey == false)
			Debug.Log("You have met me");
			player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		}
	}

	void OnTriggerExit2D(Collider2D player){
		if (player.tag == "Player"){
			player.GetComponent<Rigidbody2D> ().gravityScale = 1;
	}
}

}
