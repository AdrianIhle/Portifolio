using UnityEngine;
using System.Collections;

public class TargetHit : MonoBehaviour {



	public bool TargetIsHit;


	void OnCollisionEnter2D (Collision2D HitCollider){
		if (HitCollider.collider.tag == "Projectile") 									//If this game object's collider is hit with a object tagged "Projectile" the TargetIsHit is changed to true
	{

			Debug.Log ("B-B-Bullseye");
			TargetIsHit = true;

		}
	}
}
