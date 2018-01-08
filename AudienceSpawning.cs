using UnityEngine;
using System.Collections;
//spawns and ensures only one instance of object over all scenes
public class AudienceSpawning : MonoBehaviour {

	public GameObject Object;
	GameObject ExistingObject;


	// Use this for initialization
	void Update() {
		ExistingObject = GameObject.FindGameObjectWithTag ("Audience");
		if (ExistingObject == null) {
			Instantiate (Object, this.transform.position, Quaternion.identity * (Quaternion.Euler(0,180,0)));
		}
	}
}
