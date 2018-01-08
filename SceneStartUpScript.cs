using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// this script is designed to handle the start up of a scene, by using the scene carpet to create a visual transition to smooth the experience between level

public class SceneStartUpScript : MonoBehaviour {

	public GameObject botPosition;
	public GameObject topPosition;

	public GameObject sceneCarpet;

	public bool sceneCarpetIsUp;
    public float maxDistance = 1;


	// Use this for initialization
	void Start () {
		
		sceneCarpetIsUp = false;
		sceneCarpet.transform.position = botPosition.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!sceneCarpetIsUp)
			StartCoroutine(sceneCarpetUp());
	
	}

	IEnumerator sceneCarpetUp()
	{
        for (int i = 0; i<4; i++)
        {
            sceneCarpet.transform.Translate(Vector3.MoveTowards(transform.position, topPosition.transform.position, maxDistance * 0.5f));
            yield return new WaitForEndOfFrame();
        }
        SceneChangeScript.carpetDown = false; 
        sceneCarpetIsUp = true;
	}
}
