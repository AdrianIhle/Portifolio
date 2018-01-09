using UnityEngine;
using System.Collections;

public class CloseGameScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q))										// if 'Q' is pressed the Application quits/closes
			Application.Quit();

	}
}
