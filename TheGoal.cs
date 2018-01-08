using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// sets player movement goal and enacts it on nav mesh agent of player
public class TheGoal : MonoBehaviour {

	public Transform goal;
	UnityEngine.AI.NavMeshAgent agent;
	
		// Use this for initialization
	void Start () {
				agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {
				agent.destination = goal.position;
	}

	public void SetNewGoal(Transform goalIn)
	{
		goal = goalIn;
	}
}
