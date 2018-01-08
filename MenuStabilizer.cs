using UnityEngine;
using System.Collections;
//ensures menu on horse object remains properly oriented as it rotates
public class MenuStabilizer : MonoBehaviour {
    public Quaternion stableTransform;

	// Use this for initialization
	void Start ()
    {
        stableTransform = transform.rotation;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = stableTransform;
	}
}
