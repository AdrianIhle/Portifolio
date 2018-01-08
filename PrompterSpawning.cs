using UnityEngine;
using System.Collections;
// spawns and ensures only one instance of prompter
public class PrompterSpawning : MonoBehaviour {

	public GameObject Object;
	GameObject ExistingObject;

	// Use this for initialization
	void Start () {
		ExistingObject = GameObject.FindGameObjectWithTag ("Prompter");
		if (ExistingObject == null) {
            Instantiate(Object, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 90f)));
		}

		ExistingObject.gameObject.transform.position = this.transform.position;

	}
}
