using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sets player movement goal to position under mouse
public class Clicked : MonoBehaviour {

	public TheGoal player;

	void OnMouseDown() {
		print ("Thing clicked!");
		player.SetNewGoal (transform);
	}
}
