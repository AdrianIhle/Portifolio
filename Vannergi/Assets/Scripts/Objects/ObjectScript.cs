using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

    public bool isFixed;
    public bool rotating;
    public LocalManager objectBoss;
	// Use this for initialization
	void Start () {
        rotating = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (rotating)
        {
            this.transform.Rotate(new Vector3(0.0f, 4.0f, 0.0f));
        }

    }

    //Toggles game state of object
    public void ToggleFixed(bool state)
    {
        isFixed = state;
        objectBoss.eventHappened = true;
    }

    public void ToggleRotation(bool state)
    {
        rotating = state;
    }
}
