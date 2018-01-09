 using UnityEngine;
using System.Collections;

public class WolfWorldBehaviour : MonoBehaviour {

	public GameObject Player;																//Creates a referance to the player
	public Transform PlayerLocation;														//Creates a reference tot the players position with a seperate game object
	public Transform WolfLocation;															//creates a reference to a wolf's location with a seperate game object
	public float speed;																		//used for in editor change of speed
	public float WolfAttackDistance = 5f;													//used to set the distance from which the wolf starts attacking
	public Rigidbody2D wrb;																	//creates the reference to the wolf's rigid body
	public bool Infested;
	public Animator anim;
	Collider2D Collider;


		

	// Use this for initialization
	void Start () {
		wrb = GetComponent<Rigidbody2D> ();														//accesses the wolf's rigidbody
		PlayerLocation = PlayerLocation.GetComponent<Transform> ();								//Accesses the players location
		anim = GetComponent<Animator>();
		Collider = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
        anim.SetFloat("DistanceToPlayer", Mathf.Abs(PlayerLocation.position.x - WolfLocation.position.x));
		if (Infested) {
			anim.SetBool ("Infested", true);
			InfestedWolfBehaviour ();
		} else {
			anim.SetBool ("Infested", false);
			NormalWolfBehaviour ();
		}

	}
	IEnumerator TurnLeft(){
		yield return new WaitForSeconds (1);
		wrb.transform.Translate (new Vector2 (-speed, 0));
		GetComponent<SpriteRenderer>().flipX = false;
	}
	IEnumerator TurnRight(){
		yield return new WaitForSeconds (1);
		wrb.transform.Translate (new Vector2 (speed, 0));
		GetComponent<SpriteRenderer>().flipX = true;
	}

	void NormalWolfBehaviour(){
		bool PlayerInWorld = Player.GetComponent<controller> ().facingRight;					//detects whether the player is the world of the player by detecting the player orientation
		anim.SetBool("PlayerNotInWorld", !PlayerInWorld);
		if (Mathf.Abs (PlayerLocation.position.x - WolfLocation.position.x) <= WolfAttackDistance) {
			Collider.enabled = true;
			if (PlayerLocation.position.x < WolfLocation.position.x) {								//if player x position is less than wolf x position and the player is in the right world, the wolf moves left
				if (PlayerInWorld) {
					speed = 0.04f;
				} else{
					speed = 0;																		//if the player is not in world the wolf will not move
					Collider.enabled = false;
				}
					StartCoroutine(TurnLeft());									//moves the wolf left
			}

			if (PlayerLocation.position.x > WolfLocation.position.x) {								//if the player x position is bigger than wolf x position and the player is in the right wolrd, the wolf moves right;
				if (PlayerInWorld) {
					speed = 0.04f;
				} else {
					speed = 0;
					Collider.enabled = false;
				}
				StartCoroutine (TurnRight ());									//moves wolf right
			}
		}

		
	}

	void InfestedWolfBehaviour(){
		bool PlayerInWorld = Player.GetComponent<controller> ().facingRight;					//detects whether the player is the world of the player by detecting the player orientation
		anim.SetBool("PlayerNotInWorld", !PlayerInWorld);
		if (Mathf.Abs (PlayerLocation.position.x - WolfLocation.position.x) <= WolfAttackDistance) {
			if (PlayerLocation.position.x < WolfLocation.position.x) {								//if player x position is less than wolf x position and the player is in the right world, the wolf moves left
				if (PlayerInWorld) {
					speed = 0.04f;
				}																		//if the player is not in world the wolf will not move
				StartCoroutine(TurnLeft());									//moves the wolf left
			}
			if (PlayerLocation.position.x > WolfLocation.position.x) {								//if the player x position is bigger than wolf x position and the player is in the right wolrd, the wolf moves right;
				if (PlayerInWorld) {
					speed = 0.04f;
				}
				StartCoroutine (TurnRight ());									//moves wolf right
			}
		}
	
	}

}
