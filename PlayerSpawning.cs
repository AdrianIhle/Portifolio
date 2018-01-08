using UnityEngine;
using System.Collections;
//spawns and ensures only one instance of object over all scenes
public class PlayerSpawning : MonoBehaviour {

	public GameObject Player;
	GameObject ExistingPlayer;

	// Use this for initialization
	void Start () {
		ExistingPlayer = GameObject.FindGameObjectWithTag ("Player");
		if (ExistingPlayer == null) {
			Instantiate (Player, this.transform.position, Quaternion.identity);
		}

		ExistingPlayer.gameObject.transform.position = this.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
