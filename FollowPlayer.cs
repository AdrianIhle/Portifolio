using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void eUpdate () {
		transform.position = transform.position + new Vector3 (Player.transform.position.x, Player.transform.position.y, -13f);

	
	}
}
