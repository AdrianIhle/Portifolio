using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementScript : MonoBehaviour
{
    public GameManagement manager;
    public SFXAudioControl SFX;
    Transform player;
    public InteractionResponse.ObjectType incomingType;
    public GameObject partner;
    public FirstStageManager firstManager;
    public SecondStageManager secondManager;
    public ThirdStageManager thirdManager;
    public ForthStageManager forthManager;
    public float highlightThickness;
    bool thickning;
    bool thinning;
    MeshRenderer[] tubes;
    public int nrOfDamSections;
    int sectionsDelivered;
    public Vector3 offsetVector;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        manager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        firstManager = FindObjectOfType<FirstStageManager>();
        secondManager = FindObjectOfType<SecondStageManager>();
        thirdManager = FindObjectOfType<ThirdStageManager>();
        forthManager = FindObjectOfType<ForthStageManager>();
        SFX = GameObject.Find("SFXAudio").GetComponent<SFXAudioControl>();
        highlightThickness = 0.03f;
        thickning = true;
        if (incomingType == InteractionResponse.ObjectType.Tube)
            tubes = GetComponentsInChildren<MeshRenderer>();
        else
            tubes = new MeshRenderer[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(thickning)
            highlightThickness += 0.007f;
        if (thinning)
            highlightThickness -= 0.007f;

        if(GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().material.SetFloat("_Outline", highlightThickness);
        }
        else if(incomingType == InteractionResponse.ObjectType.Tube)
        {
            foreach(MeshRenderer m in tubes)
                m.material.SetFloat("_Outline", highlightThickness);
        }

        if(highlightThickness > 0.073)
        {
            thickning = false;
            thinning = true;
        }
        if(highlightThickness < 0.057)
        {
            thickning = true;
            thinning = false;
        }


    }
    //checks whether incoming object is correct object and acts accordingly 
    private void OnTriggerEnter(Collider other)
    {
        print(other.name + "is colliding with" + this.name);
			if (other.GetComponent<InteractionResponse> ().thisType == incomingType) {
				print ("in placement with " + incomingType + "at " + this.name);
				player.gameObject.GetComponent<InteractionUser> ().ToggleInteracting (false);
				other.GetComponent<InteractionResponse> ().ToggleInteractable (false, this.gameObject);
				other.attachedRigidbody.isKinematic = true;
				if (incomingType != InteractionResponse.ObjectType.Tube)
					GetComponent<MeshRenderer> ().enabled = false;
				else if (incomingType == InteractionResponse.ObjectType.Tube) {
					foreach (MeshRenderer m in tubes)
						m.enabled = false;
				}

				switch (incomingType) {
				case InteractionResponse.ObjectType.None:
				case InteractionResponse.ObjectType.SoundObject:
				case InteractionResponse.ObjectType.Teleporter:
					break;
				case InteractionResponse.ObjectType.Dam:
					other.transform.position = this.transform.position;
					sectionsDelivered++;
					if (sectionsDelivered == nrOfDamSections) {
						forthManager.DamGone ();
					}

					break;
				case InteractionResponse.ObjectType.Test:
                    //manager.currentGameState = GameManagement.GameState.NarrativeStarted;
                    //manager.eventHappened = true;
					other.transform.position = this.transform.position;
                    other.GetComponent<Collider>().enabled = false;
					SFX.PlaySuccess ();
					break;
				case InteractionResponse.ObjectType.Tube:
					other.transform.rotation = this.transform.rotation;
					thirdManager.eventHappened = true;
					other.transform.position = this.transform.position + offsetVector;
                    other.GetComponent<Collider>().enabled = false;
                    thirdManager.tubeNotInPlace = false;
					SFX.PlaySuccess ();
					thirdManager.provideAcknowledgement = true;
					break;
				case InteractionResponse.ObjectType.Shaft:
					thirdManager.eventHappened = true;
					other.transform.position = this.transform.position + offsetVector;
					thirdManager.shaftNotInPlace = false;
                    other.GetComponent<Collider>().enabled = false;
                    SFX.PlaySuccess ();
					thirdManager.provideAcknowledgement = true;
					break;
				case InteractionResponse.ObjectType.Turbine:
					thirdManager.eventHappened = true;
					other.transform.position = this.transform.position + offsetVector;
                    other.GetComponent<Collider>().enabled = false;
                    thirdManager.turbineOffline = false;
					SFX.PlaySuccess ();
					thirdManager.provideAcknowledgement = true;
					break;
				case InteractionResponse.ObjectType.Tutorial:
					firstManager.provideAcknowledgement = true;
					firstManager.eventHappened = true;
					firstManager.interactionInstructionsComplete = true;
                    other.GetComponent<Collider>().enabled = false;
                    print ("interaktion should be marked as done");
					other.transform.position = this.transform.position;
					SFX.PlaySuccess ();

					break;
				default:
					break;
				}


			}
		
    }
    //sets object this interaction zone is to act in accordance with
    public void SetPartner(GameObject inPartner)
    {
        partner = inPartner;
        incomingType = partner.GetComponent<InteractionResponse>().thisType;
    }

    public void ActOntype()
    {
        switch (incomingType)
        {
            case InteractionResponse.ObjectType.None:
                break;
            case InteractionResponse.ObjectType.SoundObject:
                break;
            case InteractionResponse.ObjectType.Teleporter:
                break;
            case InteractionResponse.ObjectType.Shaft:
            case InteractionResponse.ObjectType.Turbine:
            case InteractionResponse.ObjectType.Tube:
                partner.GetComponent<ObjectScript>().ToggleFixed(true);
                break;
            default:
                break;
        }
    }
}
