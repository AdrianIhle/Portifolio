using UnityEngine;
using System.Collections;

public class MovingPlatformParent : MonoBehaviour {

	void OnTriggerStay2D(Collider2D player){
		if (player.tag == "Player"){
			player.transform.parent = this.transform;
		}
	}

	void OnTriggerExit2D(Collider2D player){
		if (player.tag == "Player"){
			player.transform.parent = null; 
		}
	}
}
