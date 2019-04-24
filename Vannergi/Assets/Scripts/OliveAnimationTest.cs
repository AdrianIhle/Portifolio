using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveAnimationTest : MonoBehaviour {

	public bool moving;
	public float velocity;
	public bool pointing;
	public bool pointLeft;
	public bool pointRight;
	public bool pointForward;
	public bool machine1;
	public bool machine2;
	public bool tilt;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent < Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("moving", moving);
		anim.SetFloat ("velocity", velocity);
		anim.SetBool ("pointing", pointing);
		anim.SetBool ("machine 1", machine1);
		anim.SetBool ("machine 2", machine2);
		anim.SetBool ("tilt", tilt);
		anim.SetBool ("pointRight", pointRight);
		anim.SetBool ("pointLeft", pointLeft);
		anim.SetBool ("pointForward", pointForward);
	}
}
