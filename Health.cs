using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	public bool Dead = false;
	public float TimeToDestroy;
	Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void Update(){
		print (health);
		anim.SetBool("Dead", Dead);
	}

	void DecreaseHealth (float damage){													//updates heal by reading off damage done to them
		
		health = health- damage;
		if (health <= 0)
			Dead = true;
	}

    //	IEnumerator Death(){																		//if heath reaches 0 the scriptholder "dies" by destroying the game object
    //		Dead = true;
    //		yield return new WaitForSeconds(TimeToDestroy);
    //			Destroy (this.gameObject);
    //	}

    IEnumerator OnTriggerEnter2D(Collider2D HitCollider)
    {                                       //if the enemy encounters a collider with the name "SlamCollider" the enemy takes 2 damage and or Dies
        if (HitCollider.name == "SlamCollider")
        {
            DecreaseHealth(2);
            Debug.Log("fuck you");
            if (Dead == true)
            {
                yield return new WaitForSeconds(TimeToDestroy);
                Destroy(this.gameObject);
            }

        }
        if (HitCollider.tag == "KillZone")
        {
            DecreaseHealth(2);
            Debug.Log("AntiCrust");
            if (Dead == true)
            {
                yield return new WaitForSeconds(TimeToDestroy);
                Destroy(this.gameObject);

            }
        }
    }
  
	void OnCollisionEnter2D (Collision2D ProCollider){										//if the enemy encounters a collider with the name "SlamCollider" the enemy takes 2 damage and or Dies
		if (ProCollider.collider.tag == "Projectile") {
			DecreaseHealth (2);
			Debug.Log ("fuck you too");
		}
	}

}



