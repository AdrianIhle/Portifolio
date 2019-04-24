using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionResponse : MonoBehaviour
{

    bool activated;
    public bool playerRoaring;
    Transform player;
    Vector3 rayHitPos;
    bool movingObject;
    public Vector3 readVec;
    public bool interactable;
    public GameObject placeholder;
    public bool firstYell = false;
    FirstStageManager firstManager;
    ForthStageManager forthManager;
    public SFXAudioControl SFX;

    public enum ObjectType
    {
        None,
        Turbine,
        Shaft,
        SoundObject,
        Teleporter,
        Test,
        Tube,
        Tutorial,
        Dam,
    }

    public ObjectType thisType = ObjectType.None;

    void Start()
    {
        firstManager = FindObjectOfType<FirstStageManager>();
        forthManager = FindObjectOfType<ForthStageManager>();
        activated = false;
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        if (thisType == ObjectType.Shaft || thisType == ObjectType.Turbine || thisType == ObjectType.Test || thisType == ObjectType.Tube || thisType == ObjectType.Tutorial)
        {
            placeholder = GameObject.Find(thisType.ToString() + "Placeholder");
            placeholder.GetComponent<ObjectPlacementScript>().SetPartner(this.gameObject);
        }
        playerRoaring = false;
        interactable = true;
        SFX = GameObject.Find("SFXAudio").GetComponent<SFXAudioControl>();

    }


    
    void Update()
    {

        if (interactable)
        {
            if (activated)
            {
                switch (thisType)
                {
                    case ObjectType.None:
                        activated = false;
                        break;
                    case ObjectType.SoundObject:
                        if (playerRoaring)
                        {
                            float force = player.GetComponentInChildren<AudioInteraction>().soundForce;
                            Vector3 vec = this.transform.position - player.position;
                            SoundForce(force, vec.normalized);
                            activated = false;
                        }
                        break;

                    case ObjectType.Teleporter:
                        print("teleporter activeted");
                        if (GetComponent<TeleporterScript>())
                        {
                            print("teleporter teleporting started");
                            GetComponent<TeleporterScript>().teleporting = true;
                            activated = false;
                        }
                        break;
                    case ObjectType.Dam:
                       if (playerRoaring)
                       {
                           float force = player.GetComponentInChildren<AudioInteraction>().soundForce;
                           BlowDam(force * 2, 100.0f);
                           activated = false;
                           forthManager.DamGone();
                            GetComponent<Collider>().enabled = false;
                       }

                       break;
                    case ObjectType.Test:
                    case ObjectType.Tube:
                    case ObjectType.Shaft:
                    case ObjectType.Turbine:
                        //player.gameObject.SendMessage ("SetOrgDist", Vector3.Distance(transform.position, player.position));
                        movingObject = true;
                        activated = false;
                        player.gameObject.GetComponentInChildren<InteractionUser>().ToggleInteracting(true);

                        break;
                    case ObjectType.Tutorial:
                        movingObject = true;
                        activated = false;
                        player.gameObject.GetComponentInChildren<InteractionUser>().ToggleInteracting(true);
                        print("is it here?");
                        break;
                    default:
                        break;
                }
                print("in response with " + thisType + "at " + this.name);
                activated = false;
            }

            if (movingObject)
            {
                float placeholderPlayerDistance = Vector3.Distance(player.parent.transform.position, placeholder.transform.position);
                Vector3 placePoint = player.GetComponent<InteractionUser>().interactionVector.normalized * placeholderPlayerDistance + player.transform.parent.position;
                //transform.TransformPoint(placePoint);
                readVec = placePoint;
                MoveObjectByRayPoint(placePoint);
            }   
        }
    }


    public void ToggleActivated()
    {
        if (!activated)
            activated = true;
        else
            activated = false;
    }

    public void MoveUp()
    {
        Vector3 trans = Vector3.Lerp(transform.position, Vector3.up, 3);
        transform.Translate(trans);
    }

    public void SoundForce(float force, Vector3 forceDirection)
    {
        if(firstYell)
        {
            firstYell = true;
        }
        GetComponent<Rigidbody>().AddForce(forceDirection * force);
        //print("force enacted");
    }

    public void BlowDam(float Eforce, float radius)
    {
        GetComponent<Animator>().SetBool("explode", true);
    }

    public void MoveObjectByRayPoint(Vector3 newPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, 2);
    }

    public Vector3 RayHitToPos(Vector3 rayPos)
    {
        return rayPos;
    }

    public void SetRoar(bool state)
    {
        playerRoaring = state;
    }

    public void ToggleInteractable(bool interactablity, GameObject placeholder)
    {
        interactable = interactablity;
        GameObject sender = placeholder;
        //print("sender: " + sender.name);
        sender.GetComponent<ObjectPlacementScript>().ActOntype();
    }
}
