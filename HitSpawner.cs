using UnityEngine;
using System.Collections;

public class HitSpawner : MonoBehaviour {
	public GameObject HitCollider;
	public GameObject player;

	// Use this for initialization
	void Start () 																		//Initiates the game with the HitCollider called SlamCollider as inactive
	{
		HitCollider.SetActive (false);

	}

	// Update is called once per frame
	void Update () 
	{




		}
	 public void slam(){																//if triggered, activates the HitCollider SlamCollider

		Debug.Log ("getting there");
		HitCollider.SetActive (true);
	}



	}

