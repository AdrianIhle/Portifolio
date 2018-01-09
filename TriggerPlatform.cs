using UnityEngine;
using System.Collections;

public class TriggerPlatform : MonoBehaviour {

	public GameObject DeathTriggeredObject; 

	void Start(){
		DeathTriggeredObject.SetActive (false);
	}

	void OnDisable(){
		DeathTriggeredObject.SetActive (true);
	}
}
