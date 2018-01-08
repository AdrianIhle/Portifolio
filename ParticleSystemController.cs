using UnityEngine;
using System.Collections;
// handles platicles that communicate player death along with sound
public class ParticleSystemController : MonoBehaviour {

	bool dead;
	ParticleSystem partSys;

	// Use this for initialization
	void Start () {
		partSys = GetComponent<ParticleSystem> ();
		partSys.startColor = Color.red;

	
	}
	
	// Update is called once per frame
	void Update () {
		dead = transform.root.GetComponent<PlayerDeath> ().dead;

		if (dead)
			partSys.Emit (500);

	
	}
}
