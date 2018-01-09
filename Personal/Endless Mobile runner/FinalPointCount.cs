using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPointCount : MonoBehaviour {

	public GameObject PlayerCamera;
	PlayerPointScript PPS;

	int points;
	// Use this for initialization
	void Start () {
		PlayerCamera = GameObject.FindGameObjectWithTag ("MainCamera");	
		PPS = PlayerCamera.GetComponent<PlayerPointScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		points = PPS.points;
		this.GetComponent<Text> ().text = points.ToString ();
	}
}
