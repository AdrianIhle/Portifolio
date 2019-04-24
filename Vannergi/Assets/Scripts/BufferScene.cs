using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class BufferScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		XRSettings.enabled = false;
Load();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Load()
	{
		        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
