using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// plays sound of victims being "smashed"
public class smashEffects : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Victim")
		col.gameObject.GetComponent<AudioSource> ().Play ();
	}
}
