using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFieldMovement : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pVector = player.GetComponent<PlayerMovementPhone> ().PVelocity;
		this.gameObject.GetComponent<Rigidbody> ().AddForce (0,0, pVector.z);
	}
}
