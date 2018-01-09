using UnityEngine;
using System.Collections;

public class TriggeredPlatformBoundary : MonoBehaviour {

	public float NewSpeed = 1f;
	void OnTriggerEnter2D (Collider2D boundary){											//if a platform with the PlatformMovement script encounters this game object's collider, then the trigger inverses their movement
		Debug.Log("Zod knows no defeat");
		if (boundary.tag == "PlatformBoundary") {
			NewSpeed *= -1;
			Debug.Log ("Kneel Before Zod!");

		} 
	}
}
