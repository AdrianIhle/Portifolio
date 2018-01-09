using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {

	string currentScene;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ().name;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ResetThisLevel()
	{
		SceneManager.LoadScene (currentScene);
	}
}
