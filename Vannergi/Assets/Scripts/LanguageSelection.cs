using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LanguageSelection : MonoBehaviour {

    public LocalManager.Language language = LocalManager.Language.Norwegian;
    MainMenuScript menuScript;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        menuScript = GameObject.FindObjectOfType<MainMenuScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectEnglish()
    {
        menuScript.LanguageEnglish();
        menuScript.LanguageSelected();
    }

    public void SelectNorwegian()
    {
        menuScript.LanguageNorwegian();
        menuScript.LanguageSelected();
    }



}
