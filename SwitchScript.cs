using UnityEngine;
using System.Collections;
// skripts for toggling saw by use of a ingame lever
public class SwitchScript : MonoBehaviour {

	[HideInInspector]
	public GameObject[] TriggerBoxes;


	// Use this for initialization
	void Start () {
		TriggerBoxes = GameObject.FindGameObjectsWithTag ("SawTrigger");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pushed()
	{
		foreach (GameObject g in TriggerBoxes)
			g.GetComponent<BoxCollider> ().enabled = false;
		
	}
}
