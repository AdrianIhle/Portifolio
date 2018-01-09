using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	public bool Attacking;
	Animator anim;

	// Use this for initialization
	void Start () {
		Attacking = false;
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		anim.SetBool ("Attacking", Attacking);

	}
}
