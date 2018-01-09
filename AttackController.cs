using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {

	public ProjectileSpawn shooter; 									//accesses the ProjectileSpawn script
	public HitSpawner slammer;											// Accesses the Hitspawner script
	public GameObject HitCollider;										//creates a reference to put the SlamCollider GameObject in
	private Animator anim;												//used for animation

	public controller FaceRight;

	// Use this for initialization
	void Start () {

		anim = GetComponent < Animator> ();								 //accesses the animator of this GameObject
		FaceRight = GetComponent<controller>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl) && !FaceRight.facingRight) { 							//If 'F'  is pressed and facing right then it activates	
			anim.SetBool ("White Missile", true);							//Sets the Trigger for "Light Missile" animation
			shooter.shoot ();											//triggers the "shoot" funtion in ProjectileSpawn Script										
			StartCoroutine(DisableWhiteMisAnim());
			StartCoroutine (AttackCooldown ());
		} 
			

		if (Input.GetKeyDown (KeyCode.LeftControl) && FaceRight.facingRight) {							//If "Fire2" (Right Mouse Button) is pressed, then it activates
			anim.SetBool ("Black Slam", true);								// sets the bool for the "Black Slam" animation to true
			slammer.slam ();											//triggers the "slam" funtion in the HitSpawner Scripted (accessed throught the slammer reference)
			StartCoroutine(DisableBlackSlamAnim());
			StartCoroutine (AttackCooldown ());
		}
		else {
			HitCollider.SetActive (false);								//as long as "Fire2" is not triggered the Collider used to hit is inactive

	}
}
	IEnumerator DisableWhiteMisAnim(){
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("White Missile", false);
	}
	IEnumerator DisableBlackSlamAnim(){
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("Black Slam", false);
	}
	IEnumerator AttackCooldown (){
		GameObject.Find ("Player").GetComponent<AttackController> ().enabled = false;
		yield return new WaitForSeconds (1);
		GameObject.Find ("Player").GetComponent<AttackController> ().enabled = true;
	}
}
