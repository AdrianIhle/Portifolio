using UnityEngine;
using System.Collections;

public class StoneHealth : MonoBehaviour {

	public float health;
	public Animator anim;
	public bool Dead;
	void Start(){

	
	}

	void DecreaseHealth (float damage){													//updates heal by reading off damage done to them

		health = health- damage;
	}

	void Death(){																		//if heath reaches 0 the scriptholder "dies" by destroying the game object
		if (health <= 0) {
			Dead = true;
			GetComponent<PolygonCollider2D> ().enabled = false;
			anim.SetBool ("Dead", true);

		}
	}

	void OnTriggerEnter2D (Collider2D HitCollider){										//if the enemy encounters a collider with the name "SlamCollider" the enemy takes 2 damage and or Dies
		if (HitCollider.name == "SlamCollider") {
			DecreaseHealth (2);
			Debug.Log ("fuck you");
			Death ();
		}
	}

//	void OnCollisionEnter2D (Collision2D ProCollider){										//if the enemy encounters a collider with the name "SlamCollider" the enemy takes 2 damage and or Dies
//		if (ProCollider.collider.tag == "Projectile") {
//			DecreaseHealth (2);
//			Debug.Log ("fuck you too");
//			Death ();
//		}
//	}
}
