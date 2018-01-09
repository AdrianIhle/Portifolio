using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour {

	bool Thisenabled = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Thisenabled) {
			DisableThis ();
			Thisenabled = false;
		}
	}

	public void DisableThis()
	{
		this.gameObject.SetActive (false);
	}
}
