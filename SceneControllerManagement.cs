using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//ensures the correct scene handler is active throughout the game, as game handler object is dont destroy on load

public class SceneControllerManagement : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Scene1") {
			GetComponent<Scene1Script> ().enabled = true;
			GetComponent<scene2Script> ().enabled = false;
            GetComponent<Scene3Script>().enabled = false;
        }
		if (SceneManager.GetActiveScene ().name == "Scene2") {
			GetComponent<Scene1Script> ().enabled = false;
			GetComponent<scene2Script> ().enabled = true;
			GetComponent<Scene3Script> ().enabled = false;
		}
		if (SceneManager.GetActiveScene ().name == "Scene3") {
			GetComponent<Scene1Script> ().enabled = false;
			GetComponent<scene2Script> ().enabled = false;
			GetComponent<Scene3Script> ().enabled = true;

		}

	
	}
}
