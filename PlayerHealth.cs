using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health;																
	public GameObject DeathCamera;
	SpriteRenderer PlayerRenderer;
	Collider2D PlayerCollider;
	public float spawnLength = 0.1f;
	controller SpawnPoint;
	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
		anim.SetFloat ("Health", health);
	}

	void DecreaseHealth (float damage){													//decreases the health by damage

		health = health- damage;
    }

	IEnumerator Death(){																		//if player health reaches 0 the player dies and the level reloads
		if (health <= 0) {
			PlayerCollider = GameObject.Find ("Player").GetComponent<Collider2D> ();
			PlayerRenderer = GameObject.Find ("Player").GetComponent<SpriteRenderer> ();
			PlayerRenderer.enabled = false;
			Physics2D.IgnoreLayerCollision (8, 8, true);
			yield return new WaitForSeconds (spawnLength);
			Physics2D.IgnoreLayerCollision (8, 8, false);
			SpawnPoint = GameObject.Find("Player").GetComponent<controller>();
			transform.position = SpawnPoint.CurrentCheckPoint.position;
			PlayerRenderer.enabled = true;
		}
			
	}

	void OnCollisionEnter2D (Collision2D HitCollider){									//if the player's collider encounters the hitbox of an enemy the player looses 2 health and if that health is 0 or less the player dies
		if (HitCollider.collider.tag == "enemy") 
		{
			DecreaseHealth (2);
			Debug.Log ("fuck you");
			StartCoroutine (Death ());
		}
	}

	void OnTriggerEnter2D (Collider2D Victim){
        Debug.Log(Victim.tag);
		if (Victim.tag == "KillZone")
		{
			DecreaseHealth (2);
			Debug.Log ("fuck Gravity");
			StartCoroutine (Death ());
		}
	
	}
}



