using UnityEngine;
using System.Collections;
//spawns and ensures only one instance of object over all scenes
public class KingSpawning : MonoBehaviour {

	public GameObject Object;
	GameObject ExistingObject;

	// Use this for initialization
	void Start () {
		ExistingObject = GameObject.FindGameObjectWithTag ("King");
		if (ExistingObject == null) {
			Instantiate (Object, this.transform.position, Quaternion.identity);
		}

		ExistingObject.gameObject.transform.position = this.transform.position;

	}
}
