using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPointScript : MonoBehaviour {

    GameManagement gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
