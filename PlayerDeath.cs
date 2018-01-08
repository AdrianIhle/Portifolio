using UnityEngine;
using System.Collections;
// kills player if entering electricity or saw
public class PlayerDeath : MonoBehaviour {

	public bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		print (col.collider.name);
		if (col.collider.tag == "Saw" || col.collider.tag == "Electricity")
			dead = true;
	}
}
