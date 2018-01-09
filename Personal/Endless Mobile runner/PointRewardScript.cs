using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRewardScript : MonoBehaviour {

	public bool bamboo = false;
	public bool ramen = false;

	public GameObject PlayerCamera;
	PlayerPointScript PPS;

	public int pointsRewarded;

	// Use this for initialization
	void Start () {
		PlayerCamera = GameObject.FindGameObjectWithTag ("MainCamera");	
		PPS = PlayerCamera.GetComponent<PlayerPointScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {

			if (bamboo) {
				Award ();
			}
			else if (ramen) {
				Subtract ();
			}

			Destroy (this.gameObject);
		}
		
	}

	void Award()
	{
		print ("should award");
		PPS.points += pointsRewarded;
	}

	void Subtract()
	{
		print ("should subrtract");
		PPS.points -= pointsRewarded;
	}

		
}
