using UnityEngine;
using System.Collections;

public class TriggerActivatedElement : MonoBehaviour {

	public GameObject Trigger;															//used as a refereance to the trigger
	public bool TargetHit;																//used to indicate whether the trigger is triggered or not
	public GameObject ElementToActivate;												//used as a Referance to the game object to be activated


	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {
		TargetHit = Trigger.GetComponent<TargetHit> ().TargetIsHit;					//Reads of the bool in the Game object that is used as a trigger 
		if (TargetHit) {																//if the trigger is triggered the object will be activated
			ElementToActivate.SetActive(true);

		}

	}

}
