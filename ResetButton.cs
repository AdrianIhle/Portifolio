using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))												//If the player presses R the level resets
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
		
	}
}
