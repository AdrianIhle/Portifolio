using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
	public GameObject Player;
	GameObject Parent;
	public float FollowDistance;
	public float FollowHeight;

	Vector3 followVector;

	public bool followOnlyZ;

	// Use this for initialization
	void Start () {
		Parent = this.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		followVector = new Vector3 (0, FollowHeight, -FollowDistance);
		
	}

	void LateUpdate(){

		if (followOnlyZ)
			Parent.transform.position = new Vector3 (Parent.transform.position.x, FollowHeight, Player.transform.position.z);
		else
		Parent.transform.position = Player.transform.position + followVector;
	}
}
