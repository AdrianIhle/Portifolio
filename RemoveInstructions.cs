using UnityEngine;
using System.Collections;

public class RemoveInstructions : MonoBehaviour {

	public GameObject UI;																//creates a referance to the UI to be destroyed

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {																
		if (Input.anyKey)																//If the Player presses any thing the UI is Destroyed
			this.gameObject.SetActive (false);
	}
}
