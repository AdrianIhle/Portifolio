using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovement : MonoBehaviour {
	//movemnt for PC Debugging, should use Unity defaults axis
	public float mouseMoveAngle;
	public float moveSpeed;
	private Vector3 rotLeft;
	private Vector3 rotRight;
	private Vector3 rotUp;
	private Vector3 rotDown;

	// Use this for initialization
	void Start () {
		rotLeft = new Vector3(0, -mouseMoveAngle, 0);
		rotRight = new Vector3(0, mouseMoveAngle, 0);
		rotUp = new Vector3(-mouseMoveAngle, 0,0);
		rotDown = new Vector3(mouseMoveAngle, 0,0);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Mouse X") < 0)
		{
			this.transform.Rotate(rotLeft);
		}
		if (Input.GetAxis("Mouse X") > 0)
		{
			this.transform.Rotate(rotRight);
		}
		if (Input.GetAxis("Mouse Y") < 0)
		{
			this.transform.Rotate(rotDown);
		}
		if (Input.GetAxis("Mouse Y") > 0)
		{
			this.transform.Rotate(rotUp);
		}

		if (Input.GetKey(KeyCode.A))
		{
			this.transform.Translate(Vector3.left*moveSpeed);
		}

		if (Input.GetKey(KeyCode.S))
		{
			this.transform.Translate(Vector3.back*moveSpeed);
		}

		if (Input.GetKey(KeyCode.W))
		{
			this.transform.Translate(Vector3.forward*moveSpeed);
		}

		if (Input.GetKey(KeyCode.D))
		{
			this.transform.Translate(Vector3.right*moveSpeed);
		}

	}
}
