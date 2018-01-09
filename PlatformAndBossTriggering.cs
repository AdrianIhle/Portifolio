using UnityEngine;
using System.Collections;

public class PlatformAndBossTriggering : MonoBehaviour {

	public float Delay;
	public bool cyan;
	public bool pink;
	public bool yellow;
	public bool dark;

	public GameObject Platform;
	public GameObject Boss;


	// Use this for initialization
	void Start () {
//		Boss = GameObject.FindGameObjectWithTag ("Boss");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			print ("fuckise");
//			Boss.GetComponent<BossScript>().Attacking = true;
			yield return new WaitForSeconds (Delay);
			if (dark && cyan) {
				Platform.GetComponent<ColorInfestedPlatform> ().dark = true;
				Platform.GetComponent<ColorInfestedPlatform> ().cyan = true;
			}
			if (dark && pink) {
				Platform.GetComponent<ColorInfestedPlatform> ().dark = true;
				Platform.GetComponent<ColorInfestedPlatform> ().pink = true;
			}
			if (dark && yellow) {
				Platform.GetComponent<ColorInfestedPlatform> ().dark = true;
				Platform.GetComponent<ColorInfestedPlatform> ().yellow = true;
			}
			if (!dark && cyan) {
				Platform.GetComponent<ColorInfestedPlatform> ().dark = false;
				Platform.GetComponent<ColorInfestedPlatform> ().cyan = true;
			}
			if (!dark && pink) {
				Platform.GetComponent<ColorInfestedPlatform> ().dark = false;
				Platform.GetComponent<ColorInfestedPlatform> ().pink = true;
			}
			if (!dark && yellow) {
				Platform.GetComponent<ColorInfestedPlatform> ().dark = false;
				Platform.GetComponent<ColorInfestedPlatform> ().yellow = true;
			}

		}
	}
}
