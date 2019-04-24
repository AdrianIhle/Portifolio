using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidIOSSwitch : MonoBehaviour {

    // Use this for initialization
    public Canvas androidCanvas;
    public Canvas iosCanvas;

    private void OnEnable()
    {
#if UNITY_ANDROID
        GetComponent<HeadMovement>().enabled = true;
        GetComponent<HeadMovementiOS>().enabled = false;
        androidCanvas.enabled = true;
        iosCanvas.enabled = false;
#endif
#if UNITY_IOS
        GetComponent<HeadMovement>().enabled = false;
        GetComponent<HeadMovementiOS>().enabled = true;
                androidCanvas.enabled = false;
        iosCanvas.enabled = true;
#endif
#if Unity_EDITOR
        GetComponent<HeadMovement>().enabled = true;
        GetComponent<HeadMovementiOS>().enabled = false;
                androidCanvas.enabled = true;
        iosCanvas.enabled = false;
#endif
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
