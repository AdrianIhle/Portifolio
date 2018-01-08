using UnityEngine;
using System.Collections;
//handles effects from Unity Asset store el effect and and self made laser where uninterrupted laser keeps el field active, and interupted turns it off and allows player to move past
public class LaserLineScript : MonoBehaviour {

	Ray laserRay;
	RaycastHit laserHit;
	LineRenderer laserLine;
	public GameObject ELField;

	public AudioSource laserBuzz;
	public AudioSource ELfieldCrackle;

	public Transform lineStart;
	public Transform lineEnd;

	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		laserLine.SetPosition (0, lineStart.position);
		laserLine.enabled = true;

		laserRay.origin = transform.position;
		laserRay.direction = transform.forward;

		if(Physics.Raycast (laserRay, out laserHit))
			{
			laserLine.SetPosition (1, laserHit.point);

			if (laserHit.collider.tag == "Interactable" || laserHit.collider.tag == "Player") {
				laserBuzz.Pause ();
				ELfieldCrackle.Pause ();
				ELField.SetActive (false);
			} else {
				ELField.SetActive (true);
				ELfieldCrackle.UnPause ();
				laserBuzz.UnPause ();
			}
			}


	
	}
		

	void lineOnOff(string state)
	{
		if (state == "On") {
			laserLine.enabled = true;
		} else if (state == "Off") {
			laserLine.enabled = false;
		} else
			Debug.Log ("Wrong OnOff input(line)");
	}


}
