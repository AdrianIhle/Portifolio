using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{

		public float downForce = -1f;														//sets the amount of force used the player applies when pussing the down arrow button
		public float maxSpeed = 1f;															// sets the maximum speed of the player
		public float maxJumpSpeed = 1f;														//Sets the maximum jump 
		public float Acceleration = 1f;														// sets the acceleration
		public float objectSpeedRight;													// objects speed in right direction
		public float objectSpeedLeft;													// object speed in left direction
		public float fakeSpeed;
		public float Delay;
		public float PlatformDelay;
		public float InfestationDecayRate;
		public float FadeTime;

		public float AlphaFade;
		public float AlphaFadeP;
		public bool Faded;
		public GameObject LightWorld;														//creates a reference to the White World
		public GameObject DarkWorld;														//creates a reference to the Black World

		public Rigidbody2D rb;																// used to create a reference to the rigidbody of the gameobject
		public float gravity;																// used t set a custon gravity
		public float speed = 2f;															// sets a speed
		public float jumpSpeed = 1f;														// sets jump speed

		public bool grounded;																// used to allow or not allwo jumping by detecting whether the player is on the ground or not
		public Transform groundCheck;														//creates the 'physical' detector in game
		float groundRadius = 0.2f;															// sets the distance from the ground that the ground check should activate
		public LayerMask whatIsGround;														// used to sepearate between  what is wolrd and what is not world or not

		public Camera WorldCamera;
//		public Camera WhiteWorldCam;														//creates a reference to put the White World Camera on
//		public Camera BlackWorldCam;														//creates a reference to put the Black World Camera on
		public Camera WhitePWCamera;
		public Camera BlackPWCamera;

		public GameObject WalkingSound;

		public bool facingRight;															//used to determine whether the player is facing right or not
		public bool Infested;
		public bool TransitionLightToDark;
		public bool TransitionDarkToLight;

		public Transform CurrentCheckPoint;
		Animator anim;																		// creates a reference to the players Animator
		public Canvas PauseMenu;


		// Use this for initialization
		void Start()
		{
			rb = GetComponent<Rigidbody2D>();												//accesses the RigidBody of this game object
//			WhiteWorldCam.enabled = false;													//when the game object is initiated the White World Camera is turned off
//			BlackWorldCam.enabled = true;													//When the game object is Initiated the Black World Camera is turned on
			TransitionLightToDark = true;
			TransitionDarkToLight = false;
			PauseMenu.enabled = false;
			WalkingSound.SetActive (false);
			PlatformDelay = Delay + 0.2f;

			anim = GetComponent<Animator>();												//accesses the animator of thie game object

		AlphaFade = 1;
		AlphaFadeP = 0;
		FadeTime = Delay;

		}
		

		// Update is called once per frame
		void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); // Defines when grounded is true by checking whether Groundcheks position overlaps with what is ground within the groundRadius

		anim.SetBool ("Grounded", grounded);													//tells the animator whether the character is grounded or not

		anim.SetFloat ("vSpeed", rb.velocity.y);												//tells the animator the vertical velocity of the player 
		anim.SetFloat ("Speed", fakeSpeed);
		fakeSpeed = 0;

        if (Input.GetKey (KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) {	//if the left Arrow Key is Pressed and the player is not moving above max speed, this activates
			anim.SetBool ("Facing Right", false);											//sets the facing right bool in the animator to false
			fakeSpeed = -1f;
			rb.transform.Translate (Vector2.left * objectSpeedLeft * Acceleration * Time.deltaTime);							//makes the player move left 
			jumpSpeed = 700;
			TransitionLightToDark = true;
			TransitionDarkToLight = false;
			StartCoroutine (SwitchDelayLeft ());
			StartCoroutine (PlatformSwitchDelayLeft ());
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				StopCoroutine (SwitchDelayLeft ());
				StopCoroutine (PlatformSwitchDelayLeft ());
			}
		} 

		if (TransitionLightToDark)
			LightToDark ();

		if (Input.GetKey (KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) {	//if right arrow key is pressed and player velocity is less than maxs speed, activates
			anim.SetBool ("Facing Right", true);											//Tells animator to set Facing right as true
			fakeSpeed = 1f;
			rb.transform.Translate (Vector2.right * objectSpeedRight * Acceleration * Time.deltaTime);						//makes the player move right
			jumpSpeed = 700;
			TransitionDarkToLight = true;
			TransitionLightToDark = false;
			StartCoroutine (SwitchDelayRight ());
			StartCoroutine (PlatformSwitchDelayRight ());
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				StopCoroutine (SwitchDelayRight ());
				StopCoroutine (PlatformSwitchDelayRight ());
			}
		}
		if (TransitionDarkToLight)
			DarkToLight ();


		if(!(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)||(Input.GetKey (KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))) && grounded)
			jumpSpeed = 650;
			


		if (Input.GetKeyDown (KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) {											//allows the player to and downwards force to adjust jumps and falls
			rb.AddForce(new Vector2(0,downForce));}


		if (Input.GetKey (KeyCode.Q))
			Application.Quit ();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 1f;
			PauseMenu.enabled = true;
		}
		if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) && grounded)
			WalkingSound.SetActive (true);
		else
			WalkingSound.SetActive (false);

	}
		void Update(){
		BlackPWCamera.enabled = false;
		WhitePWCamera.enabled = false;

		if ((grounded && Input.GetKeyDown(KeyCode.W ))||(grounded && Input.GetKeyDown(KeyCode.Space))||(grounded && Input.GetKeyDown(KeyCode.UpArrow)))									//once  up arrow button is pressed, this triggers
			{	
				anim.SetBool("Grounded", false);												// tells animator the character is not grounded
			rb.AddForce(Vector2.up*jumpSpeed);											// makes the player jump										
			}

		if ((Input.GetKey (KeyCode.LeftShift) && facingRight)||(Input.GetKey (KeyCode.RightShift) && facingRight))
			BlackPWCamera.enabled = true;
		if ((Input.GetKey (KeyCode.LeftShift) && !facingRight)||(Input.GetKey (KeyCode.RightShift) && !facingRight))
			WhitePWCamera.enabled = true;
		if ((Input.GetKeyUp (KeyCode.LeftShift) && facingRight)||(Input.GetKeyUp (KeyCode.RightShift) && facingRight))
			BlackPWCamera.enabled = false;
		if ((Input.GetKeyUp (KeyCode.LeftShift) && !facingRight)||(Input.GetKeyUp (KeyCode.RightShift) && !facingRight))
			WhitePWCamera.enabled = false;


			
		}

    void LateUpdate()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);          //keeps the player from going transperant along with platforms when they become parent
    }

	IEnumerator InfestationDecay()
	{
		yield return new WaitForSeconds (InfestationDecayRate);
		Infested = false;
	}

	IEnumerator SwitchDelayLeft(){
		yield return new WaitForSeconds (Delay);
		Physics2D.IgnoreLayerCollision (8, 10, false);									//deactivates player interaction with Black World
		Physics2D.IgnoreLayerCollision (8, 9, true);									//activates player interaction with White World
//		WhiteWorldCam.enabled = false;													//deactivates visual  the white world
//		BlackWorldCam.enabled = true;													// deactivates visuals of the black world
		facingRight = false;															//indicates the player is not facing right
	}

	IEnumerator SwitchDelayRight(){

		yield return new WaitForSeconds (Delay);
		Physics2D.IgnoreLayerCollision (8, 9, false);									// deactivates interaction with black world
		Physics2D.IgnoreLayerCollision (8, 10, true);									//activates interaction with white world	
//		WhiteWorldCam.enabled = true;													//activates white world visuals 
//		BlackWorldCam.enabled = false;													//deactiaves black world visuals
		facingRight = true;																//indicates the player is facing right
	}

	IEnumerator PlatformSwitchDelayLeft(){
		yield return new WaitForSeconds (PlatformDelay);
		Physics2D.IgnoreLayerCollision(8,14, false);
		Physics2D.IgnoreLayerCollision(8,15, true);
	}

	IEnumerator PlatformSwitchDelayRight(){
		
		yield return new WaitForSeconds (PlatformDelay);
		Physics2D.IgnoreLayerCollision(8,15, false);
		Physics2D.IgnoreLayerCollision(8,14, true);
	}

	void DarkFadeOut(){
			foreach (SpriteRenderer sr in DarkWorld.GetComponentsInChildren<SpriteRenderer>()) {
				sr.material.color = new Color (AlphaFade, AlphaFade, AlphaFade, AlphaFade);
			}
	}

	void DarkFadeIn(){
		foreach (SpriteRenderer sr in DarkWorld.GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = new Color (AlphaFade, AlphaFade, AlphaFade, AlphaFade);
		}
	}


	void LightFadeIn(){
			foreach (SpriteRenderer sr in LightWorld.GetComponentsInChildren<SpriteRenderer>()) {
				sr.material.color = new Color (AlphaFadeP, AlphaFadeP, AlphaFadeP, AlphaFadeP);
			}
	}

	void LightFadeOut(){
		foreach (SpriteRenderer sr in LightWorld.GetComponentsInChildren<SpriteRenderer>()) {
				sr.material.color = new Color (AlphaFadeP, AlphaFadeP, AlphaFadeP, AlphaFadeP);
			}
		}

	void LightToDark(){
		AlphaFadeP = Mathf.Clamp01(AlphaFadeP - (Time.deltaTime / FadeTime));
		AlphaFade = Mathf.Clamp01(AlphaFade + (Time.deltaTime / FadeTime));
		LightFadeOut ();
		DarkFadeIn ();
	}

	void DarkToLight(){
		AlphaFadeP = Mathf.Clamp01(AlphaFadeP + (Time.deltaTime / FadeTime));
		AlphaFade = Mathf.Clamp01(AlphaFade - (Time.deltaTime / FadeTime));
		LightFadeIn ();
		DarkFadeOut ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "color") {
			Infested = true;
			StartCoroutine (InfestationDecay ());
		}
	}


	}

