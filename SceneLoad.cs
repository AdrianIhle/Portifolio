using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {

    public int Level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player")
			UnityEngine.SceneManagement.SceneManager.LoadScene (Level);							//Enter scene number or name within Parantheses
	}
}
