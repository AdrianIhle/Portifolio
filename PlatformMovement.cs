using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {



	public float speed;


	public GameObject platform;

	// Use this for initialization
	void Start () {
		

	}   
	// Update is called once per frame
	void Update () {

			NormalBehaviour ();

	}

	void NormalBehaviour(){


			speed = GetComponent<TriggeredPlatformBoundary> ().NewSpeed;
		Debug.Log ("Kal Zora, soup of the World");

		platform.transform.Translate(new Vector2(speed, 0));
	}
}
