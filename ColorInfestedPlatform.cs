using UnityEngine;
using System.Collections;

public class ColorInfestedPlatform : MonoBehaviour {

	public bool cyan;
	public bool pink;
	public bool yellow;
	public bool dark;

	public bool InversingGravity = false;
	public bool FadingPlatform = false;

	public GameObject Player;
	public GameObject Boss;

	public float AlphaFade;
	public float AlphaFadeP;
	public GameObject Platform;
	public bool Faded;

	public GameObject Storm;
	Animator anim;
	// Use this for initialization
	void Start () {
 			AlphaFade = 1f;
			AlphaFadeP = 0f;
		anim = GetComponent<Animator> ();

//		Storm = GameObject.Find ("InfestationStorm");
	}
	
	// Update is called once per frame
	//Preveiw FUck over
	//
	void FixedUpdate(){
		anim.SetBool ("Cyan", cyan);
		anim.SetBool ("Pink", pink);
		anim.SetBool ("Yellow", yellow);
		anim.SetBool ("Dark", dark);

		if (dark)
			this.gameObject.layer = 10;					//layer dark world
		if (!dark)
			this.gameObject.layer = 9;					//layer light world


		if (InversingGravity)
			InverseGravity ();
		if (FadingPlatform) {
			AlphaFade -= Mathf.Clamp01 (Time.deltaTime / 5f);
			StartCoroutine (PlatformFadeOut ());
//			if (Faded) {
//				AlphaFadeP += Mathf.Clamp01 (Time.deltaTime / 5f);
//				StartCoroutine (PlatformFadeIn ());
//			}

		}
		
		
	}


	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			if (cyan) {
				InversingGravity = true;
				if (InversingGravity == true)
					StartCoroutine (EndInvertedGravity ());
					
			}

			if (pink) {
				FadingPlatform = true; 

			}

			if (yellow) {
				Storm.SetActive (true);

			}
		}
	
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.tag == "Player") {
			Physics2D.gravity = new Vector2 (0f, -30f);
			Player.transform.localRotation = new Quaternion (0, 0, 0, 0);
			StartCoroutine (PreviewStormEnd ());
		}
		
	}


	IEnumerator PlatformFadeOut(){
		Platform.GetComponent<SpriteRenderer>().color = new Color (AlphaFade, AlphaFade, AlphaFade, AlphaFade);
		yield return new WaitForSeconds (7f);
		Faded = true;
		Platform.SetActive (false);
	}

	IEnumerator PlatformFadeIn(){
		Platform.GetComponent<SpriteRenderer>().color = new Color (AlphaFadeP, AlphaFadeP, AlphaFadeP, AlphaFadeP);
		yield return new WaitForSeconds (7f);
	}

	IEnumerator PreviewStormEnd(){
		yield return new WaitForSeconds (5f);
		Storm.SetActive (false);
	}

	IEnumerator EndInvertedGravity(){
		yield return new WaitForSeconds (2f);
	InversingGravity = false;
		cyan = false;
		yield return new WaitForSeconds (2f);
		cyan = true;

	}

	void InverseGravity(){
		Physics2D.gravity = new Vector2 (0f, 10f);
		Player.transform.localRotation = new Quaternion (0, 0, 180, 0);
	}
		
}
