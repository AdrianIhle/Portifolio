using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//scene manager for scene, documents and controls all overarching variables
//bools detect player actions, gameobjects used to act out changes and int is for recording what reaction audiences have to the act
public class Scene3Script : MonoBehaviour
{

    //these bools are used to trigger if statements in Scenario() to generate responses from audience and prompter, they are set to false again at the end if its given if statement.
    public bool digUpSkull;
    public bool talkToSkull;
    public bool digUpBush;
    public bool crownSkull;
    public bool digUpTombstone;
    public bool skullLuteMetal;
    public bool swordHitSkull;

    //read off from Inventory, these bools are used to determine the actions available to the player
    public bool crownInHand;
    public bool luteInHand;
    public bool shovelInHand;
    public bool swordInHand;
    public bool skullInHand;

    //this bool is used to trigger audience reactions
    public bool AudienceReacts;

    //used to access various interactiable buttons
    public Button digUpDirtButton;
    public Button digUpGraveButton;
    public Button digUpBushButton;
    public Button showSkullButton;



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

        if (digUpSkull) 
        {
            AudienceReacts = true;
            AudienceReaction = positive;
            PlaySound("Items", "ShovelDig", true);
        }
        if (talkToSkull) 
        {
            AudienceReacts = true;
            AudienceReaction = veryPostitive;
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Tada", true);
        }
        if (digUpBush)
        {
            AudienceReacts = true;
            AudienceReaction = positive;
            PlaySound("Items", "ShovelDig", true);
            PlaySound("Items", "BushCrunch", true);

        }
        if (crownSkull)
        {
            AudienceReacts = true;
            AudienceReaction = veryPostitive;
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Tada", true);


        }
        if (digUpTombstone)
        {
            AudienceReacts = true;
            AudienceReaction = veryNegative;
            PlaySound("Items", "ShovelDig", true);


        }
        if (skullLuteMetal)
        {
            AudienceReacts = true;
            AudienceReaction = veryPostitive;
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "MetalLute", true);
            skullLuteMetal = false;

        }
        if (swordHitSkull)
        {
            AudienceReacts = true;
            AudienceReaction = negative;
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "SwordAttack", true); //change the sound of swordattack from swordWhup to swordDraw

        }
    }



    //by reading off the bools in inventory this function turns on and off interaction possibilites 
    void ActionAvailable()
    {
        if (crownInHand)
        {
        }
        else
        {
        }

		if (shovelInHand) {
			digUpDirtButton.interactable = true;
			digUpBushButton.interactable = true;
			digUpGraveButton.interactable = true;
		} else {
			digUpDirtButton.interactable = false;
			digUpBushButton.interactable = false;
			digUpGraveButton.interactable = false;
		}
		

        if (swordInHand)
        {
        }
        else
        {
        }

        if (skullInHand)
            showSkullButton.interactable = true;
        else
            showSkullButton.interactable = false;


    }
		

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void OnEnable()
    {
		digUpDirtButton = GameObject.Find("digUpDirtButton").GetComponent<Button>();
		digUpGraveButton = GameObject.Find("digUpGraveButton").GetComponent<Button>();
		digUpBushButton = GameObject.Find("digUpBushButton").GetComponent<Button>();
        showSkullButton = GameObject.Find("showSkullButton").GetComponent<Button>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    // Use this for initialization
    void Start()
    {
        AudienceReaction = 1;                                       //sets the Audience's starting reaction
        Inventory = GameObject.Find("BindToCollider");              //finds the gameobject that acts as inventory
        guards = GameObject.FindGameObjectsWithTag("Guard");        //Finds the guards
        prompter = GameObject.Find("Prompter");                 //Finds the Prompter
        Audience = GameObject.FindGameObjectWithTag("Audience");    //finds the audience 
		Player = GameObject.FindGameObjectWithTag("Player");
        InitialSoundOff();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentScene = SceneManager.GetActiveScene();

        //acquires all the required variables needed and keeps them up to date
        itemInHand = Inventory.GetComponent<Inventory>().itemInHand;

        crownInHand = Inventory.GetComponent<Inventory>().crownInHand;
        luteInHand = Inventory.GetComponent<Inventory>().luteInHand;
        shovelInHand = Inventory.GetComponent<Inventory>().shovelInHand;
        swordInHand = Inventory.GetComponent<Inventory>().swordInHand;
        skullInHand = Inventory.GetComponent<Inventory>().skullInHand;

		digUpSkull = Player.GetComponent<BoolsForReset>().digUpSkull;
		talkToSkull = Player.GetComponent<BoolsForReset>().talkToSkull;
		digUpBush = Player.GetComponent<BoolsForReset>().digUpBush2;
		digUpTombstone = Player.GetComponent<BoolsForReset>().digUpTombstone;
        swordHitSkull = Player.GetComponent<BoolsForReset>().swordHitSkull;

        //calls upon ActionsAvailable() and Scenario to keep the players options up to date.
        ActionAvailable();
        Scenario();

    }

    void Update()
    {
        playBackgroundMusic();
    }


    void LateUpdate()
    {
        //Turns off audience reaction after the frame is done so it doesnt loop
        AudienceReacts = false;
        Debug.Log("audience reacts disabled");
    }

    void playBackgroundMusic()
    {
        GameObject soundParent;
        GameObject music;
        soundParent = GameObject.FindGameObjectWithTag("BackgroundMusic");
        if (currentScene.name == "Scene1")
        {
            music = soundParent.transform.FindChild("SceneOne").gameObject;

            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                music.GetComponentInChildren<AudioSource>().Play();
            }

        }
        if (currentScene.name == "Scene2")
        {

            music = soundParent.transform.FindChild("SceneTwo").gameObject;

            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                music.GetComponentInChildren<AudioSource>().Play();
            }
        }

    }


    void PlaySound(string soundRoot, string soundObject, bool play)
    {
        GameObject soundParent;
        GameObject soundRootObject;
        GameObject sound;

        soundParent = GameObject.FindGameObjectWithTag("sfxAudio");
        if (play)
        {

            if (soundRoot == "King")
            {
                soundRootObject = soundParent.transform.FindChild("King").gameObject;
                if (soundObject == "Aww")
                {
                    sound = soundRootObject.transform.FindChild("Aww").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                else if (soundObject == "Choke")
                {
                    sound = soundRootObject.transform.FindChild("Choke").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                else if (soundObject == "ClearThroat")
                {
                    sound = soundRootObject.transform.FindChild("ClearThroat").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                else if (soundObject == "Gasp")
                {
                    sound = soundRootObject.transform.FindChild("Gasp").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                else if (soundObject == "No")
                {
                    sound = soundRootObject.transform.FindChild("No").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                else if (soundObject == "Scream")
                {
                    sound = soundRootObject.transform.FindChild("Scream").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
            }

            if (soundRoot == "Guards")
            {
                soundRootObject = soundParent.transform.FindChild("Guards").gameObject;
                if (soundObject == "Angry")
                {
                    sound = soundRootObject.transform.FindChild("Angry").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "Groan")
                {
                    sound = soundRootObject.transform.FindChild("Groan").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "Oohh")
                {
                    sound = soundRootObject.transform.FindChild("Oohh").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "Unexpected")
                {
                    sound = soundRootObject.transform.FindChild("Unexpected").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "Yeah")
                {
                    sound = soundRootObject.transform.FindChild("Yeah").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
            }

            if (soundRoot == "Prompter")
            {
                soundRootObject = soundParent.transform.FindChild("Prompter").gameObject;
                if (soundObject == "Whisper")
                {
                    sound = soundRootObject.transform.FindChild("WhisperOne").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
            }

            if (soundRoot == "Items")
            {
                soundRootObject = soundParent.transform.FindChild("Items").gameObject;
                if (soundObject == "DropSword")
                {
                    sound = soundRootObject.transform.FindChild("DropSword").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "ShovelDig")
                {
                    sound = soundRootObject.transform.FindChild("ShovelDig").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "ShovelDump")
                {
                    sound = soundRootObject.transform.FindChild("ShovelDump").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "BushCrunch")
                {
                    sound = soundRootObject.transform.FindChild("BushCrunch").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "DrawSword")
                {
                    sound = soundRootObject.transform.FindChild("DrawSword").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
            }

            play = false;
        }
    }


    void InitialSoundOff()
    {
        AudioSource[] sfxSounds;

        sfxSounds = GameObject.FindGameObjectWithTag("sfxAudio").GetComponentsInChildren<AudioSource>();

        foreach (AudioSource sound in sfxSounds)
            sound.Stop();

        AudioSource[] music;

        music = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponentsInChildren<AudioSource>();

        foreach (AudioSource sound in music)
            sound.Stop();
    }
    // due to audience its important that Scenario() remains in Update!!
}