using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeParent : MonoBehaviour {

	public GameObject Parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		this.transform.position = Parent.transform.position;
	}
}
