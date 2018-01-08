using UnityEngine;
using System.Collections;
//handles 
public class SawTriggerScript : MonoBehaviour {

	public GameObject sawPivot;
	public float speed;
	public float waitTime;
	public float upDistance;

	Vector3 targetPos;
	Vector3 inverseTargetPos;
	Vector3 startPos;
	Vector3 invertedStartPos;
	Quaternion rotation;
	Quaternion current;


	public bool inverse;
	public bool active;
	public bool retracting;
	public bool buttonPushed;

	public AudioSource sawCont;

//sets position for start position of saw and the target position for the saw
	// Use this for initialization
	void Start () {
		targetPos = new Vector3 (0, 0, 160);
		inverseTargetPos = new Vector3 (0, 0, -160);
		startPos = new Vector3 (0, 0, -160);
		invertedStartPos = new Vector3 (0, 0, 160);


	}
	
	// Update is called once per frame
	void FixedUpdate () {

//if active and handels movement according to inverse bool

		if (active) {

			if (!inverse) {
				rotation = Quaternion.LookRotation (targetPos);
				current = sawPivot.transform.rotation;
				sawPivot.transform.rotation = Quaternion.Slerp (current, rotation, Time.deltaTime * speed);
			} else {
				rotation = Quaternion.LookRotation (inverseTargetPos);
				current = sawPivot.transform.rotation;
				sawPivot.transform.rotation = Quaternion.Slerp (current, rotation, Time.deltaTime * speed);
			}
			StartCoroutine( deactivationDelay (waitTime));
		}

		if (retracting) {
			sawPivot.transform.position = Vector3.Lerp (sawPivot.transform.position, new Vector3(sawPivot.transform.position.x, sawPivot.transform.position.y + upDistance, sawPivot.transform.position.z), speed/5);
			sawCont.Pause ();
		}
	} 

// player triggers movement of saw	

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player" || col.tag == "Staff") {
			active = true;
		}
	}

	public void triggerSaw()
	{
		active = true;
	}

	public void PushButton ()
	{
		buttonPushed = true;
	}
// delays action to allow player reaction
	public IEnumerator deactivationDelay(float wait)
	{
		yield return new WaitForSeconds (wait);
		active = false;
		yield return new WaitForSeconds (wait);
		if (buttonPushed) {
			retracting = true;
		}

	}
}
