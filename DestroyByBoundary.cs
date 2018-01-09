using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	public GameObject projectile;


	void OnTriggerEnter2D(Collider2D other) //detects triggers
	{	
		print (other.tag);					//prints the tag of the collider
		Debug.Log ("Hei");					
		Destroy (other.gameObject);			//destroys the game object of 
	}

}
		






