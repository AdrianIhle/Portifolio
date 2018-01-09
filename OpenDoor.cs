using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public GameObject Trigger;															//used as a reference to the trigger
	public bool TargetHit;																//used to indicate whether the trigger is triggered or not
	public GameObject ElementToDestroy;													//used as a Referance to the game object to be destroyed


	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		TargetHit = Trigger.GetComponent<TargetHit> ().TargetIsHit;					//Reads the bool in the Game object that is used as a trigger 
		if (TargetHit) {															//if the trigger is triggered the object wil be destroyed
			Destroy (ElementToDestroy);
		
		}
		
	}

}


