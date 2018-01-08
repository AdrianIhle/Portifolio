using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//scene manager for scene, documents and controls all overarching variables
//bools detect player actions, gameobjects used to act out changes and int is for recording what reaction audiences have to the act
public class Scene1Script : MonoBehaviour {

	//these bools are used to trigger if statements in Scenario() to generate responses from audience and prompter, they are set to false again at the end if its given if statement.
	public bool crownOnKing;
	public bool crownOnGuard;
	public bool playedLute;
	public bool crownSkull;
	public bool showSkull;
	public bool showShovel;
	public bool attackKing;
	public bool attackGuard;
	public bool crownSelf;

	//read off from Inventory, these bools are used to determine the actions available to the player
	public bool crownInHand;
	public bool luteInHand;
	public bool shovelInHand;
	public bool swordInHand;
	public bool skullInHand;

	//this bool is used to trigger audience reactions
	public bool AudienceReacts;

	//used to access various interactiable buttons
	public Button crownTheKingButton;
	public Button playForTheCourtButton;
	public Button attackTheKingButton;
	public Button showSkullButton;

	public GameObject[] attackGuardButtonObjects;
	public GameObject[] crownGuardButtonObjects;


	//accesses the guards available
	GameObject[] guards;

	//used as a reference to inventory and the king
	GameObject Inventory;
	PopUp KingEmoji;

	//used to access the prompter 
	public GameObject prompter;
	public GameObject Audience;
	public GameObject Player;

	Scene currentScene;

	//used as a reference to the items held in hand
	int itemInHand;

	//used to reference the reaction the audiecne will ahve and the variables used to alter that reaction
	public int AudienceReaction;
	int veryPostitive = 4;
	int positive = 3;
	int negative = 2;
	int veryNegative = 1;

	//this function triggers behaviour depending on the action taken by the player
	void Scenario()
	{

		if (crownOnKing)
		{
			Player.GetComponent<BoolsForReset> ().crownOnKing = false;
			AudienceReacts = true;
			AudienceReaction = veryPostitive;
			crownTheKingButton.GetComponent<Image> ().color = Color.green;
			crownTheKingButton.enabled = false;
			Player.GetComponent<PlayerAudioScript> ().PlaySound ("Player", "Tada", true);
			Debug.Log ("All hail the king");
		}
		if (crownOnGuard)
		{
			Player.GetComponent<BoolsForReset> ().crownOnGuard = false;
			AudienceReacts = true;
			AudienceReaction = positive;
			foreach (GameObject button in attackGuardButtonObjects) 
			{
				button.GetComponent<Image> ().color = Color.green;
				button.GetComponent<Button> ().enabled = false;
			}
			PlaySound ("Guard", "Yeah", true);
			PlaySound ("Guard", "Unexpected", true);
			PlaySound ("King", "No", true);
			//prompter if needed
		}
		if (playedLute)
		{
			Player.GetComponent<BoolsForReset> ().playedLute = false;
			AudienceReacts = true;
			AudienceReaction = negative;
			playForTheCourtButton.GetComponent<Image> ().color = Color.red;
			playForTheCourtButton.enabled = false;
			PlaySound ("Guard", "Oohh", true);
			PlaySound ("King", "ClearThroat", true);
			//prompter if needed

		}
		if (crownSkull)
		{
			AudienceReacts = true;
			AudienceReaction = veryPostitive;
			showSkullButton.GetComponent<Image> ().color = Color.red;
			showSkullButton.enabled = false;
			PlaySound ("King", "Gasp", true);
			PlaySound ("Guard", "Unexpected", true);
			PlaySound ("Guard", "Unexpected", true);
			//prompter if needed
			crownSkull = false;

		}
		if (showSkull)
		{
			Player.GetComponent<BoolsForReset> ().showSkull = false;
			AudienceReacts = true;
			AudienceReaction = negative;
			Player.GetComponent<PlayerAudioScript>().PlaySound("Player","Tada",true);
			PlaySound("King", "ClearThroat", true);
			Debug.Log ("hey skully");


		}
		if (showShovel)
		{
			AudienceReacts = true;
			AudienceReaction = negative;
			Player.GetComponent<PlayerAudioScript>().PlaySound("Player","Tada",true);
			//prompter if needed
			showShovel = false;

		}
		if (attackKing)
		{
			Player.GetComponent<BoolsForReset> ().attackKing = false;
			AudienceReacts = true;
			AudienceReaction = veryPostitive;
			attackTheKingButton.GetComponent<Image> ().color = Color.green;
			attackTheKingButton.enabled = false;
			PlaySound ("King", "Scream", true);
			Player.GetComponent<PlayerAudioScript>().PlaySound("Player","SwordAttack",true); 

		}
		if (attackGuard)
		{
			Player.GetComponent<BoolsForReset> ().attackKing = false;
			AudienceReacts = true;
			AudienceReaction = positive;
			//prompter if needed
			foreach (GameObject button in crownGuardButtonObjects) 
			{
				button.GetComponent<Image> ().color = Color.green;
				button.GetComponent<Button> ().enabled = false;
			}
			PlaySound ("Guard", "Angry", true);
			PlaySound ("King", "Gasp", true);
			Player.GetComponent<PlayerAudioScript>().PlaySound("Player","Attack",true);

		}
		if (crownSelf)
		{
			AudienceReacts = true;
			AudienceReaction = positive;
			Player.GetComponent<PlayerAudioScript>().PlaySound("Player","Triumph",true);
			PlaySound ("King", "No", true);
			crownSelf = false;

		}

	}


	//by reading off the bools in inventory this function turns on and off interaction possibilites 
	void ActionAvailable(){
		if (crownInHand) {
			crownTheKingButton.interactable = true;
			enableGuardButtons (crownGuardButtonObjects);
		} 
		else 
		{
			crownTheKingButton.interactable = false;
			disableGuardButtons (crownGuardButtonObjects);
		}

		if (luteInHand) 
		{
			playForTheCourtButton.interactable = true;
		}
		else
			playForTheCourtButton.interactable = false;

		if (swordInHand) 
		{
			attackTheKingButton.interactable = true;
			enableGuardButtons (attackGuardButtonObjects);
		} 
		else 
		{
			attackTheKingButton.interactable = false;
			disableGuardButtons (attackGuardButtonObjects);
		}

		if (skullInHand)
			showSkullButton.interactable = true;
		else
			showSkullButton.interactable = false;


	}

	void disableGuardButtons(GameObject[] Buttons)
	{
		Debug.Log ("disabling");
		foreach (GameObject button in Buttons) 
		{
			button.GetComponent<Button> ().interactable = false;
		}
	}

	void enableGuardButtons(GameObject[] Buttons)
	{
		Debug.Log ("enabling");
		foreach (GameObject button in Buttons) 
		{
			button.GetComponent<Button> ().interactable = true;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad (this);

	}

	void OnEnable()
	{
		crownGuardButtonObjects = GameObject.FindGameObjectsWithTag ("CrownGuardButton");
		attackGuardButtonObjects = GameObject.FindGameObjectsWithTag ("AttackGuardButton");
		crownTheKingButton = GameObject.Find ("crownTheKingButton").GetComponent<Button> ();
		playForTheCourtButton = GameObject.Find ("playForTheCourtButton").GetComponent<Button> ();
		attackTheKingButton = GameObject.Find ("attackTheKingButton").GetComponent<Button> ();
		showSkullButton = GameObject.Find ("showSkullButton").GetComponent<Button> ();

	}
		

	// Use this for initialization
	void Start () {
		AudienceReaction = 1;										//sets the Audience's starting reaction
		Inventory = GameObject.Find ("BindToCollider");				//finds the gameobject that acts as inventory
		guards = GameObject.FindGameObjectsWithTag ("Guard");		//Finds the guards
		prompter = GameObject.Find ("Prompter");					//Finds the Prompter
		Audience = GameObject.FindGameObjectWithTag ("Audience");	//finds the audience 
		Player = GameObject.FindGameObjectWithTag ("Player");
		InitialSoundOff();



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentScene = SceneManager.GetActiveScene ();

		//acquires all the required variables needed and keeps them up to date
		itemInHand = Inventory.GetComponent<Inventory> ().itemInHand;

		crownInHand = Inventory.GetComponent<Inventory> ().crownInHand;
		luteInHand = Inventory.GetComponent<Inventory> ().luteInHand;
		shovelInHand = Inventory.GetComponent<Inventory> ().shovelInHand;
		swordInHand = Inventory.GetComponent<Inventory> ().swordInHand;
		skullInHand = Inventory.GetComponent<Inventory> ().skullInHand;

		crownOnKing = Player.GetComponent<BoolsForReset> ().crownOnKing;
		crownOnGuard = Player.GetComponent<BoolsForReset> ().crownOnGuard;
		playedLute = Player.GetComponent<BoolsForReset> ().playedLute;
		showSkull = Player.GetComponent<BoolsForReset> ().showSkull;
		attackKing = Player.GetComponent<BoolsForReset> ().attackKing;
		attackGuard = Player.GetComponent<BoolsForReset> ().attackGuard;

		ActionAvailable ();
		Scenario();
	
	}

	void Update()
	{
		playBackgroundMusic ();
	}
		

	void LateUpdate(){
			AudienceReacts = false;
		Debug.Log ("audience reacts disabled");
	}

	void playBackgroundMusic()
	{
		GameObject soundParent;
		GameObject music;
			soundParent = GameObject.FindGameObjectWithTag ("BackgroundMusic");
			if (currentScene.name == "Scene1") 
			{
				music = soundParent.transform.FindChild ("SceneOne").gameObject;

				if(!music.GetComponent<AudioSource>().isPlaying){
				music.GetComponentInChildren<AudioSource> ().Play ();
			}

			}
		if (currentScene.name == "Scene2") 
		{
			
			music = soundParent.transform.FindChild ("SceneTwo").gameObject;

			if(!music.GetComponent<AudioSource>().isPlaying){
				music.GetComponentInChildren<AudioSource> ().Play ();
			}
		}

	}


	void PlaySound (string soundRoot, string soundObject, bool play)
	{
		GameObject soundParent;
		GameObject soundRootObject;
		GameObject sound;

		soundParent = GameObject.FindGameObjectWithTag ("sfxAudio");
		if (play) {

			if(soundRoot == "King")
			{
				soundRootObject = soundParent.transform.FindChild ("King").gameObject;
				if(soundObject == "Aww")
				{
					sound = soundRootObject.transform.FindChild ("Aww").gameObject;
					sound.GetComponent<AudioSource> ().Play (); 
				}
				else if(soundObject == "Choke")
				{
					sound = soundRootObject.transform.FindChild ("Choke").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "ClearThroat" )
				{
					sound = soundRootObject.transform.FindChild ("ClearThroat").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "Gasp")
				{
					sound = soundRootObject.transform.FindChild ("Gasp").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "No" )
				{
					sound = soundRootObject.transform.FindChild ("No").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "Scream" )
				{
					sound = soundRootObject.transform.FindChild ("Scream").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
			}

			if(soundRoot == "Guards")
			{
				soundRootObject = soundParent.transform.FindChild("Guards").gameObject;
				if(soundObject == "Angry")
				{
					sound = soundRootObject.transform.FindChild ("Angry").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject == "Groan")
				{
					sound = soundRootObject.transform.FindChild ("Groan").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject == "Oohh")
				{
					sound = soundRootObject.transform.FindChild ("Oohh").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject == "Unexpected")
				{
					sound = soundRootObject.transform.FindChild ("Unexpected").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject == "Yeah")
				{
					sound = soundRootObject.transform.FindChild ("Yeah").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
			}
				
			if(soundRoot == "Prompter")
			{
				soundRootObject = soundParent.transform.FindChild("Prompter").gameObject;
				if(soundObject =="Whisper" )
				{
					sound = soundRootObject.transform.FindChild ("WhisperOne").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
			}

			if(soundRoot == "Items")
			{
				soundRootObject = soundParent.transform.FindChild("Items").gameObject;
				if(soundObject =="DropSword" )
				{
					sound = soundRootObject.transform.FindChild ("DropSword").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject =="ShovelDig" )
				{
					sound = soundRootObject.transform.FindChild ("ShovelDig").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject =="ShovelDump" )
				{
					sound = soundRootObject.transform.FindChild ("ShovelDump").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject =="BushCrunch" )
				{
					sound = soundRootObject.transform.FindChild ("BushCrunch").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				if(soundObject =="" )
				{
					sound = soundRootObject.transform.FindChild ("DrawSword").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
			}

			play = false;
		}


	}
		

	void InitialSoundOff()
	{
		AudioSource[] sfxSounds;

		sfxSounds = GameObject.FindGameObjectWithTag ("sfxAudio").GetComponentsInChildren<AudioSource> ();

		foreach (AudioSource sound in sfxSounds)
			sound.Stop ();

		AudioSource[] music;

		music = GameObject.FindGameObjectWithTag ("BackgroundMusic").GetComponentsInChildren<AudioSource> ();

		foreach (AudioSource sound in music)
			sound.Stop ();

		
	}

	// due to audience its important that Scenario() remains in Update!!
		
}
