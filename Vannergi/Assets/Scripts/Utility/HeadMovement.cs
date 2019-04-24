using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {
    //aquires the rotation of a devices gyro, and applies its rotation to the object of the script

    public Quaternion attitude;
	public Quaternion rotation; 

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update () {

		attitude = Input.gyro.attitude;

#if UNITY_IOS
        SetLocalRotation(attitude.y, attitude.x, attitude.z, attitude.w);
#endif

#if UNITY_ANDROID
        transform.localRotation.Set (attitude.x, attitude.y, attitude.z, attitude.w);
#endif
    }

    void SetLocalRotation(float x, float y, float z, float w)
    {
        transform.localRotation = new Quaternion(x, y, z, w);
    }
}
