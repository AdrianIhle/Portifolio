

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoadScript : MonoBehaviour {

	public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
	public int sceneToLoad;
	AsyncOperation operation;
	Scene currentScene;
	public Image progressBar;
	public Text loadingText;
	public Canvas loadCanvas;

	public float loadRead;

	float waitOnLoadEnd = 0.25f;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene();

		loadCanvas.gameObject.SetActive (true);
		StartCoroutine (AsyncLevelLoad (currentScene.buildIndex+1));
	}


		

	void StartOperation(int scene)
	{
		operation = SceneManager.LoadSceneAsync(scene, loadSceneMode);


		if (loadSceneMode == LoadSceneMode.Single)
			operation.allowSceneActivation = false;
	}

	IEnumerator AsyncLevelLoad(int scene)
	{
		yield return null; 

		StartOperation(scene);

		 float lastProgress = 0f;

		// operation does not auto-activate scene, so it's stuck at 0.9
		while (DoneLoading() == false) {
			yield return null;

			if (Mathf.Approximately(operation.progress, lastProgress) == false) {
				progressBar.fillAmount = operation.progress;
				lastProgress = operation.progress;
				loadRead = lastProgress;
			}
		}
			


		yield return new WaitForSeconds(waitOnLoadEnd);

		yield return new WaitForSeconds(0.25f);
			operation.allowSceneActivation = true;
	}

	private bool DoneLoading() 
	{
		return (loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f); 
	}


}