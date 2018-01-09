using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

//	void Update(){
//		if (Input.GetKey (KeyCode.Escape))
//			ExitPauseMenu ();
//	}

	 public void ExitPauseMenu(){
		Time.timeScale = 1;
		this.gameObject.SetActive(false);
	}

	public void ExitGame (){
		Application.Quit();
	}
	
	}

