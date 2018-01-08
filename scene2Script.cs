using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//scene manager for scene, documents and controls all overarching variables
//bools detect player actions, gameobjects used to act out changes and int is for recording what reaction audiences have to the act
public class scene2Script : MonoBehaviour {

	public bool playedSerenade;
	public bool playedMetal;
	public bool showedSkull;
	public bool hideInBush;
	public bool digUpBush;
	public bool crownSelf2;
	public bool fenceAtJuliet;

	public bool crownInHand;
	public bool luteInHand;
	public bool shovelInHand;
	public bool swordInHand;
	public bool skullInHand;

	public bool AudienceReacts;

	GameObject Inventory;

	public GameObject Audience;
	public GameObject prompter;
	public GameObject Player;

	int itemInHand;

	public int AudienceReaction;
	int veryPostitive = 4;
	int positive = 3;
	int negative = 2;
	int veryNegative = 1;

	public Button serenadeButton;
	public Button guitarSoloButton;
	public Button showSkullButton;
	public Button fenceWithButton;

	Scene currentScene;



	void Scenario(){
		if (playedSerenade) {
			Player.GetComponent<BoolsForReset> ().playedSerenade = false;
			AudienceReacts = true;
			AudienceReaction = veryPostitive;
			PlaySound("Juliet","SexyOh", true);
			Debug.Log ("sexy ohing should commence");
			prompter.GetComponent<PrompterAI> ().scene2Prompt1 = true;
		}
		if (playedMetal) {
			Player.GetComponent<BoolsForReset> ().playedMetal2 = false;
			AudienceReacts = true;
			AudienceReaction = veryPostitive;
			PlaySound ("Juliet", "Giggling", true);
			prompter.GetComponent<PrompterAI> ().scene2Prompt2 = true;
		}
		if (showedSkull) {
			Player.GetComponent<BoolsForReset> ().showedSkull2 = false;
			AudienceReacts = true;
			AudienceReaction = veryNegative;
			PlaySound ("Juliet", "Gasp", true);
		}
		if (hideInBush) {
			Player.GetComponent<BoolsForReset> ().hideInBush = false;
			AudienceReacts = true;
			AudienceReaction = negative;
			PlaySound ("Juliet", "ConfusedAhh", true);
		}
		if (digUpBush) {
			Player.GetComponent<BoolsForReset> ().digUpBush = false;
			AudienceReacts = true;
			AudienceReaction = positive;
			PlaySound ("Juliet", "AngryNo", true);
		}
		if (crownSelf2) {
			Player.GetComponent<BoolsForReset> ().crownSelf2 = false;
			AudienceReacts = true;
			AudienceReaction = veryPostitive;
			PlaySound("Juliet","SexyOh", true);
			prompter.GetComponent<PrompterAI> ().scene2Prompt3 = true;
		}
		if (fenceAtJuliet) {
			Player.GetComponent<BoolsForReset> ().fenceAtJuliet = false;
			AudienceReacts = true;
			AudienceReaction = veryNegative;
			PlaySound ("Juliet", "AngryNo", true);
		}
	}

	void ActionAvailable(){
		
		if (luteInHand)
			serenadeButton.interactable = true;
		else
			serenadeButton.interactable = false;

		if (luteInHand)
			guitarSoloButton.interactable = true;
		else
			guitarSoloButton.interactable = false;

		if (swordInHand)
			fenceWithButton.interactable = true;
		else
			fenceWithButton.interactable = false;

		if (skullInHand)
			showSkullButton.interactable = true;
		else
			showSkullButton.interactable = false;

	}

	void Start()
	{

		Debug.Log ("OnENable was used");
		Player = GameObject.FindGameObjectWithTag ("Player");

		AudienceReaction = 1;
		Inventory = GameObject.Find ("BindToCollider");
		prompter = GameObject.Find ("Prompter");
		Audience = GameObject.FindGameObjectWithTag ("Audience");
		InitialSoundOff ();

	}
	void FixedUpdate () {
		currentScene = SceneManager.GetActiveScene ();
		Debug.Log (currentScene.name);
		itemInHand = Inventory.GetComponent<Inventory> ().itemInHand;

		crownInHand = Inventory.GetComponent<Inventory> ().crownInHand;
		luteInHand = Inventory.GetComponent<Inventory> ().luteInHand;
		shovelInHand = Inventory.GetComponent<Inventory> ().shovelInHand;
		swordInHand = Inventory.GetComponent<Inventory> ().swordInHand;
		skullInHand = Inventory.GetComponent<Inventory> ().skullInHand;

		playedSerenade = Player.GetComponent<BoolsForReset> ().playedSerenade;
		playedMetal = Player.GetComponent<BoolsForReset> ().playedMetal2;
		showedSkull = Player.GetComponent<BoolsForReset> ().showedSkull2;
		fenceAtJuliet = Player.GetComponent<BoolsForReset> ().fenceAtJuliet;
		digUpBush = Player.GetComponent<BoolsForReset> ().digUpBush;
		hideInBush = Player.GetComponent<BoolsForReset> ().hideInBush;
		crownSelf2 = Player.GetComponent<BoolsForReset> ().crownSelf2;


		ActionAvailable ();
		Scenario();

	}

	void Update()
	{
		serenadeButton = GameObject.Find ("serenadeButton").GetComponent<Button>();
		guitarSoloButton = GameObject.Find ("guitarSoloButton").GetComponent<Button>();
		showSkullButton = GameObject.Find ("showSkullButton").GetComponent<Button>();
		fenceWithButton = GameObject.Find ("fenceWithButton").GetComponent<Button>();

		playBackgroundMusic ();
	}

	void LateUpdate(){
		if (AudienceReacts)
			AudienceReacts = false;
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

			if(soundRoot == "Juliet")
			{
				soundRootObject = soundParent.transform.FindChild ("Juliet").gameObject;
				if(soundObject == "AngryNo")
				{
					sound = soundRootObject.transform.FindChild ("AngryNo").gameObject;
					sound.GetComponent<AudioSource> ().Play (); 
				}
				else if(soundObject == "ConfusedAhh")
				{
					sound = soundRootObject.transform.FindChild ("ConfusedAhh").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "Gasp" )
				{
					sound = soundRootObject.transform.FindChild ("Gasp").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "Giggling")
				{
					sound = soundRootObject.transform.FindChild ("Giggling").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
				else if(soundObject == "SexyOh" )
				{
					Debug.Log ("Sexy ohing");
					sound = soundRootObject.transform.FindChild ("SexyOh").gameObject;
					sound.GetComponent<AudioSource> ().Play ();
				}
			}
				

			if(soundRoot == "Prompter")
			{
				soundRootObject = soundParent.transform.FindChild("Prompter").gameObject;
				if(soundObject =="Whisper" )
				{
					sound = soundRootObject.transform.FindChild ("WhisperTwo").gameObject;
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
