using UnityEngine;
using System.Collections;
// handles turing on and off spolight which reveals a piece of the puzzle to get past chasm
public class SpotLightScrpt : MonoBehaviour {

	public Light spotlight;
	public GameObject inSpotLight;
	public Light[] sceneSpots;

	// Use this for initialization
	void Start () {
		spotlight = GetComponentInChildren<Light> ();
		sceneSpots = GameObject.Find ("SpotLights").GetComponentsInChildren<Light> ();
		spotlight.enabled = false;
		inSpotLight.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


				
	
	}

	public void turnOn()
	{
		spotlight.enabled = true;
		foreach (Light l in sceneSpots) {
			l.enabled = false;
		}
		inSpotLight.SetActive (true);
	}

	public void turnOff()
	{
		spotlight.enabled = false;
		foreach (Light l in sceneSpots) {
			l.enabled = true;
		}
		inSpotLight.SetActive (false);
	}
}
