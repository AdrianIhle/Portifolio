using UnityEngine;
using System.Collections;

public class RockEnemyPhase : MonoBehaviour {

	public GameObject Player;															//Used to reference to the Player character
	public bool PlayerInWorld;															//bool to detect which way the player is facing (which world)
	public GameObject RockEnemy;														//used to reference to the game object acting as the actual enemy
	public GameObject Rock;																//used to reference to the game object acting as a platform in the other world
	public bool Infested;																//bool to determine which behaviour the enemy will use


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		Infested = RockEnemy.GetComponent<EnemyBoundaryMovement> ().Infested;			//ensures that the Infested bool of this script is the same as that of the actual enemy
		if (Infested)																	
			InfestedBehaviour ();
		else
			NormalBehaviour ();
		
	}

	void NormalBehaviour(){																//works fine, no issues
		bool PlayerInWorld = Player.GetComponent<controller> ().facingRight;
		if (PlayerInWorld) {
			RockEnemy.SetActive (false);
			Rock.SetActive (true);
		}

		if (!PlayerInWorld) {
			RockEnemy.SetActive (true);
			Rock.SetActive (false);
		}
	}

	void InfestedBehaviour(){
		bool PlayerInWorld = Player.GetComponent<controller> ().facingRight;			//enemy simply disappears from in game but remains in the editor and some time times pop up in-game as the player transistions, but disappears
		RockEnemy.layer = 9;
		Rock.layer = 10;
		if (!PlayerInWorld) {
			RockEnemy.SetActive (false);
			Rock.SetActive (true);
		}

		if (PlayerInWorld) {
			RockEnemy.SetActive (true);
			Rock.SetActive (false);
		}

	}
}
