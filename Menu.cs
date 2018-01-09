using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

	public Canvas MainCanvas;
	public Canvas OptionsMenu;

	void Awake(){
		OptionsMenu.enabled = false;

	}

	public void OptionsOn(){
		OptionsMenu.enabled = true;
		MainCanvas.enabled = false;
	}

	public void ReturnFromOptions ()
	{
		OptionsMenu.enabled = false;
		MainCanvas.enabled = true;
	}

	public void LoadOn(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

	public void Quit(){
		Application.Quit ();
	}

}
