using UnityEngine;
using System.Collections;

public class PickupColorInfestation : MonoBehaviour {

	public GameObject InfestationStorm;
	public bool StormActive = false;
	public float AlphaFade;
	ParticleSystemRenderer PRS;

	// Use this for initialization
	void Start () {
//		AlphaFade = 1;
		InfestationStorm.SetActive (false);
//		PRS = InfestationStorm.GetComponentsInChildren<ParticleSystemRenderer> ()[ParticleSystem.];

	}
	
//	 Update is called once per frame
//	void Update () {
//			if(StormActive){
//			AlphaFade -= Mathf.Clamp01 (Time.deltaTime / 5f);
//			PRS.material.color = new Color (AlphaFade, AlphaFade, AlphaFade, AlphaFade);
//
//		}
//	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			StartCoroutine (StormDuration ());
		}
			
	}

	IEnumerator StormDuration(){
		StormActive = true;
		InfestationStorm.SetActive (true);

		yield return new WaitForSeconds (10f);
		StormActive = false;
		InfestationStorm.SetActive (false);
		AlphaFade = 1;
	}
}
