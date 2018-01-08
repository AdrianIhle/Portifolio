using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//ensures there is only one of an item between scene loads
public class NoRespawnScript : MonoBehaviour {
    public PickUpScript pickUp;
    public GameObject objectToggable;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        pickUp = gameObject.GetComponentInChildren<PickUpScript>();
        objectToggable = pickUp.gameObject;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!pickUp.holding && pickUp.currentScene != SceneManager.GetActiveScene().buildIndex)
            objectToggable.SetActive(false);
        else if (pickUp.holding || pickUp.currentScene == SceneManager.GetActiveScene().buildIndex)
            objectToggable.SetActive(true);
    }
}
