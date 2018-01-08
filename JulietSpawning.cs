using UnityEngine;
using System.Collections;
//handles interactions for specified object
public class JulietSpawning : MonoBehaviour {

	public GameObject Object;
	GameObject ExistingObject;

	// Use this for initialization
	void Start () {
		ExistingObject = GameObject.FindGameObjectWithTag ("Juliet");
		if (ExistingObject == null) {
			Instantiate (Object, this.transform.position, Quaternion.identity);
		}

		ExistingObject.gameObject.transform.position = this.transform.position;

	}
}
