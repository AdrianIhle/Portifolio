using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class MainMenuScript : MonoBehaviour {
	private const string MIC_PERMISSION = "android.permission.RECORD_AUDIO";

    public LanguageSelection langSel;
    public Button norBut, engBut;
    AsyncOperation async;

	// Use this for initialization
	void Start () {
       // XRSettings.enabled = false;
        langSel = FindObjectOfType<LanguageSelection>();
        LanguageSelected();
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.RequestUserAuthorization(UserAuthorization.Microphone);
           if (Application.HasUserAuthorization(UserAuthorization.Microphone))
           {
               Microphone.Start("Built -in Microphone", true, 1, 44100);
           }
           else
           {
               print(" did not get mic permit, iphone");
           }
        }

        if(Application.platform == RuntimePlatform.Android)
            AskPermission ();

        StartCoroutine(LoadScene());
    }
	
	// Update is called once per frame
	void Update () {
	}

    //uss plugin from Git to ask for anidroid permission, in this case for use of Microphone
	public void AskPermission()
	{
		AndroidPermissionsManager.RequestPermission(new []{MIC_PERMISSION}, new AndroidPermissionCallback(
			grantedPermission =>
			{

			},
			deniedPermission =>
			{

			}
		)
		);
	}
    //Loads scene after delay, delay put in to ensure that the player is asked for permission, should the app not have it
	IEnumerator LoadScene()
	{
		async = SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex + 1);
        async.allowSceneActivation = false;
        yield return async;
	}

    public void ActivateScene()
    {
      // XRSettings.enabled = true;
        async.allowSceneActivation = true;
    }

    public void SelectLanguage()
    {
        norBut.gameObject.SetActive(true);
        engBut.gameObject.SetActive(true);
    }

    public void LanguageEnglish()
    {
        langSel.language = LocalManager.Language.English;
        LanguageSelected();
    }

    public void LanguageNorwegian()
    {
        langSel.language = LocalManager.Language.Norwegian;
        LanguageSelected();
    }

    public void LanguageSelected()
    {
        norBut.gameObject.SetActive(false);
        engBut.gameObject.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
