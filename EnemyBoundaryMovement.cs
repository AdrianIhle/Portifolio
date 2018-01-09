using UnityEngine;
using System.Collections;
 
public class EnemyBoundaryMovement : MonoBehaviour {
	 
     public GameObject Player;
     public float speed;
	 public float Speed;
	public bool Infested;
 
	Animator anim;
     public Rigidbody2D erb;

     // Use this for initialization
     void Start () {
		Speed = Mathf.Abs (speed);
         erb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();



     
     }   
    // Update is called once per frame
    void FixedUpdate () {
 	
		anim.SetBool ("Infested", Infested);
		anim.SetFloat ("Speed", speed);

		if (Infested)
			InfestedRockBehaviour ();
			else
			NormalBehaviour ();

		if (speed > 0)
			GetComponent<SpriteRenderer> ().flipX = true;
		else
			GetComponent<SpriteRenderer> ().flipX = false;
		
     }

	void NormalBehaviour(){

		bool PlayerInWorld = Player.GetComponent<controller> ().facingRight;

		if (PlayerInWorld){
			speed = 0;
	}
		else
			speed = GetComponent<TriggeredBoundary> ().NewSpeed;
		

		erb.transform.Translate(new Vector2(speed, 0));
	}

	void InfestedRockBehaviour(){
		bool PlayerInWorld = Player.GetComponent<controller> ().facingRight;
		if (PlayerInWorld) {
			speed = GetComponent<TriggeredBoundary> ().NewSpeed;

		} else {
			speed = 0;
		}
		erb.transform.Translate (new Vector2 (speed, 0));
	}
}
