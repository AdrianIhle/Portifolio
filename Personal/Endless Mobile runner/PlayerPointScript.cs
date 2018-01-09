using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointScript : MonoBehaviour {

	public int points;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponentInChildren<Text> ().text = points.ToString ();
	}
}
