using UnityEngine;
using System.Collections;

public class PlatformMovementY : MonoBehaviour {



	public float speed;


	public GameObject platform;

	void Update () {

			NormalBehaviour ();
	}

	void NormalBehaviour(){

			speed = GetComponent<TriggeredPlatformBoundary> ().NewSpeed;

		platform.transform.Translate(new Vector2(0, speed));
	}
}
