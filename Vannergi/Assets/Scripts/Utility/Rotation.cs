using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public bool rotate;
	public float speed;
	Vector3 rotVec;
	public enum RotAxis
	{
		x,y,z,}

	public RotAxis axis;

	// Use this for initialization
	void Update () {
		switch (axis) {
		case RotAxis.x:
			rotVec = new Vector3 (speed, 0, 0);
			break;
		case RotAxis.y:
			rotVec = new Vector3 (0, speed, 0);
			break;
		case RotAxis.z:
			rotVec = new Vector3 (0, 0, speed);
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rotate)
			this.transform.Rotate (rotVec);
	}
}
