using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//scene manager for scene, documents and controls all overarching variables
//bools detect player actions, gameobjects used to act out changes and int is for recording what reaction audiences have to the act

public class Scene4Script : MonoBehaviour
{

    //these bools are used to trigger if statements in Scenario() to generate responses from audience and prompter, they are set to false again at the end if its given if statement.
    public bool mountHorse;
    public bool SwordOnKnight;
    public bool SwordOnHorse;
    public bool showSkullToHorse;
    public bool playLute4;
    public bool KnightHit;
    public bool crownHorse;
    public bool shovelOnKnight;

    //read off from Inventory, these bools are used to determine the actions available to the player
    public bool crownInHand;
    public bool luteInHand;
    public bool shovelInHand;
    public bool swordInHand;
    public bool skullInHand;

    //this bool is used to trigger audience reactions
    public bool AudienceReacts;

    //used to access various interactiable buttons
    public Button AttackKnightButton;
    public Button UseShovelButton;
    public Button UseLuteButton;
    public Button showSkullButton;
	public Button MountButton;
	public Button UnmountButton;
	public Button AttackButton;
	public Button UseCrownButton;

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

        if (mountHorse)
        {
            Player.GetComponent<BoolsForReset>().mountHorse = false;
            AudienceReacts = true;
            AudienceReaction = positive;
            PlaySound("Horse", "NeighHuman", true);
        }
        if (SwordOnKnight) //Attack knight with sword; Win
        {
            Player.GetComponent<BoolsForReset>().SwordOnKnight = false;
            AudienceReacts = true;
            AudienceReaction = veryPostitive;
            PlaySound("Items", "DrawSword", true);
            PlaySound("Horse", "NeighMech", true);
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Triumph", true);
            prompter.GetComponent<PrompterAI>().scene4Prompt1 = true;
        }
        if (SwordOnHorse) //Attack horse.. Action: Sword/Horse; Target: Own Horse;
        {
            Player.GetComponent<BoolsForReset>().SwordOnHorse = false;
            AudienceReacts = true;
            AudienceReaction = veryNegative;
            PlaySound("Items", "DrawSword", true);
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Attack", true);
            PlaySound("Horse", "Snort", true);

        }
        if (showSkullToHorse) //Hand: Skull
        {
            Player.GetComponent<BoolsForReset>().showSkullToHorse = false;
            AudienceReacts = true;
            AudienceReaction = veryNegative;
            PlaySound("Horse", "Snort", true);
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Tada", true);
            showSkullButton.GetComponent<Image>().color = Color.red;
            showSkullButton.enabled = false;

        }
        if (playLute4) //Play lute to the knight; Hand: Lute
        {
            Player.GetComponent<BoolsForReset>().playLute4 = false;
            AudienceReacts = true;
            AudienceReaction = veryPostitive;
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "PlayLute", true);
            prompter.GetComponent<PrompterAI>().scene4Prompt3 = true;
        }
        if (KnightHit) //Knight defeats the player; Hand: Nothing
        {
            Player.GetComponent<BoolsForReset>().KnightHit = false;
            AudienceReacts = true;
            AudienceReaction = negative;
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Hurt", true);
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "SwordAttack", true);
			AttackKnightButton.GetComponent<Image>().color = Color.red;
			AttackKnightButton.enabled = false;

        }
        if (crownHorse) //Hand: Crown
        {
            Player.GetComponent<BoolsForReset>().crownHorse = false;
            AudienceReacts = true;
            AudienceReaction = positive;
            PlaySound("Horse", "SnortThree", true);
			UseCrownButton.GetComponent<Image>().color = Color.green;
			UseCrownButton.enabled = false;

        }
        if (shovelOnKnight)
        {
            Player.GetComponent<BoolsForReset>().shovelOnKnight = false;
            AudienceReacts = true;
            AudienceReaction = veryPostitive;
            PlaySound("Horse", "NeighMech", true);
            Player.GetComponent<PlayerAudioScript>().PlaySound("Player", "Triumph", true);
            prompter.GetComponent<PrompterAI>().scene4Prompt2 = true;
			UseShovelButton.GetComponent<Image>().color = Color.green;
			UseShovelButton.enabled = false;
        }
    }


    //by reading off the bools in inventory this function turns on and off interaction possibilites 
    void ActionAvailable()
    {
        if (crownInHand)
        {
			UseCrownButton.interactable = true;
            enableGuardButtons(crownGuardButtonObjects);
        }
        else
        {
			UseCrownButton.interactable = false;
            disableGuardButtons(crownGuardButtonObjects);
        }

        if (luteInHand)
        {
			UseLuteButton.interactable = true;
        }
        else
			UseLuteButton.interactable = false;

		if (shovelInHand) {
			UseShovelButton.interactable = true;
		
		} else {
			UseLuteButton.interactable = false;
		}

        if (swordInHand)
        {
			AttackKnightButton.interactable = true;
			AttackButton.interactable = true;
        }
        else
        {
			AttackKnightButton.interactable = false;
			AttackButton.interactable = false;
        }

        if (skullInHand)
            showSkullButton.interactable = true;
        else
            showSkullButton.interactable = false;


    }


    // enables and disables buttons for arrays
    void disableGuardButtons(GameObject[] Buttons)
    {
        Debug.Log("disabling");
        foreach (GameObject button in Buttons)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    void enableGuardButtons(GameObject[] Buttons)
    {
        Debug.Log("enabling");
        foreach (GameObject button in Buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);    //ensures gamehandler is not destroyed to track progress of level to the rest of the game
    }

    void OnEnable()
    {
		AttackKnightButton = GameObject.Find("AttackKnightButton").GetComponent<Button>();
		UseShovelButton = GameObject.Find("UseShovelButton").GetComponent<Button>();
		UseLuteButton = GameObject.Find("UseLuteButton").GetComponent<Button>();
		MountButton = GameObject.Find("MountButton").GetComponent<Button>();
		UnmountButton = GameObject.Find("UnmountButton").GetComponent<Button>();
        showSkullButton = GameObject.Find("ShowSkullButton").GetComponent<Button>();
		AttackButton = GameObject.Find("AttackButton").GetComponent<Button>();
		UseCrownButton = GameObject.Find("UseCrownButton").GetComponent<Button>();
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

        mountHorse = Player.GetComponent<BoolsForReset>().mountHorse;
        SwordOnKnight = Player.GetComponent<BoolsForReset>().SwordOnKnight;
        SwordOnHorse = Player.GetComponent<BoolsForReset>().SwordOnHorse;
        showSkullToHorse = Player.GetComponent<BoolsForReset> ().showSkullToHorse;
        playLute4 = Player.GetComponent<BoolsForReset>().playLute4;
        KnightHit = Player.GetComponent<BoolsForReset> ().KnightHit;
        crownHorse = Player.GetComponent<BoolsForReset>().crownHorse;
		shovelOnKnight = Player.GetComponent<BoolsForReset> ().shovelOnKnight;


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

    //plays background music based on scene, no music for scene 3 and 4
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

    //acquires sound and plays one time, can be converted to PlayOneShot()
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
            if (soundRoot == "Horse")
            {
                soundRootObject = soundParent.transform.FindChild("Horse").gameObject;
                if (soundObject == "NeighHuman")
                {
                    sound = soundRootObject.transform.FindChild("NeighHuman").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "NeighMech")
                {
                    sound = soundRootObject.transform.FindChild("NeighMech").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "Snort")
                {
                    sound = soundRootObject.transform.FindChild("Snort").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "SnortLong")
                {
                    sound = soundRootObject.transform.FindChild("SnortLong").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "SnortThree")
                {
                    sound = soundRootObject.transform.FindChild("SnortThree").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
                if (soundObject == "Running")
                {
                    sound = soundRootObject.transform.FindChild("Running").gameObject;
                    sound.GetComponent<AudioSource>().Play();
                }
            }

            play = false;
        }


    }

    //cleans sound for start of level 
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
