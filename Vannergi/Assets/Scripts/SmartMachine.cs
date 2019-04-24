using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMachine : MonoBehaviour {

    public Transform ballPos;
    FirstStageManager firstManager;
    public SFXAudioControl SFX;
    // Use this for initialization
    void Start () {
        firstManager = FindObjectOfType<FirstStageManager>();
        SFX = GameObject.Find("SFXAudio").GetComponent<SFXAudioControl>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "SoundInteractive")
        {
            print("ball colliding");
            col.rigidbody.isKinematic = true;
            col.transform.GetComponent<Collider>().enabled = false;
            col.transform.position = ballPos.position;

            if (firstManager.soundInstrcutionsComplete == false)
            {
                firstManager.provideAcknowledgement = true;
                firstManager.soundInstrcutionsComplete = true;
                SFX.PlaySuccess();
                firstManager.eventHappened = true;
                print("eventing in sound");
            }
        }
    }
}
