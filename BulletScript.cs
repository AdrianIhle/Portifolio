using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public Rigidbody2D bullet;													// used to access the the Rigidbody of the projectile
	public float bulletLife = 2;												//  sets the frames of the life of the bullet

	// Use this for initialization
	void Start () {
	bullet = GetComponent<Rigidbody2D> ();										// the functions that specifically gets the Rigidbody of the projectile

	
	}
	
	// Update is called once per frame
	public float bulletForce = 1f;												// sets the quantity of the bullets force/speed
	void Update () 
	{
		bulletLife--;															// reduces the bullet life counter each frame
		bullet.AddForce (new Vector2 (-bulletForce, 0));						// propels the bullet along in 2D space by travelling the X axis by negative bulletforce each frame and the Y with 0 each frame

		if(bulletLife == 0)														// if the projectile has outlived its life this triggers
			DestroyObject (gameObject);											// detroys the projectile (the gameobject it is attached to)
		}

	void OnCollisionEnter2D(Collision2D world){									// detects collisons
		if (world.collider.tag == "world")										//  if the collider it collides with is tagged "world" it destroys the projectile
			DestroyObject (gameObject);
		}

	}
	
