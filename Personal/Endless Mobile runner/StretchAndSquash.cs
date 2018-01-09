using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchAndSquash : MonoBehaviour {

	public float speed;
	public float StretchFactor;
	public float interval; 

	float startTime;

	public float Timer;

	Vector3 originalScale;
	Vector3 scalingY;


	public bool triggerY;

	public bool stretchingY;

	public bool squashingY; 


	// Use this for initialization
	void Start () {
		originalScale = this.transform.localScale;
		scalingY= new Vector3 (originalScale.x, originalScale.y * StretchFactor, originalScale.z);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (triggerY == true)
			StartCoroutine (StrNSqhY ());


		if (stretchingY) {
			Stretch (scalingY);
		}
		if (squashingY) {
			Squash (scalingY);
		}
			
	}

	void Stretch (Vector3 targetScale)
	{
		float scalingLeft = Vector3.Distance (originalScale, targetScale);
		float currentDuration = Time.time - startTime;
		float journeyFraction = currentDuration / scalingLeft;
		transform.localScale = Vector3.Slerp (originalScale, targetScale, journeyFraction);
		Timer = journeyFraction;
	}

	void Squash(Vector3 targetScale)
	{

		float scalingLeft = Vector3.Distance (originalScale, targetScale);
		float currentDuration = Time.time - startTime;
		float journeyFraction = currentDuration / scalingLeft;
		transform.localScale = Vector3.Slerp(targetScale,originalScale, journeyFraction);
		Timer = journeyFraction;

	}



	public IEnumerator StrNSqhY()
	{
		triggerY = false;
		startTime = Time.time;
		print ("triggered y");
		stretchingY = true;
		yield return new WaitForSeconds (interval);
		stretchingY = false;
		startTime = Time.time;
		squashingY = true;
		yield return new WaitForSeconds (interval);
		squashingY = false;

		print ("triggered y ends");


	}
		

		
}
