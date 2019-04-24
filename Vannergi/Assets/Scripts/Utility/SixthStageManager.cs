    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthStageManager : LocalManager {

    public bool endingNarrative;
    public bool introduceFreeRoam;
    public GameObject geysirTeleport;
    public Transform buttonPoint, adressPoint;
    public NutOMatic nutmachine;

    private new void Start()
    {
        base.Start();
        geysirTeleport.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if(eventHappened)
        {
            print("sixthstage event");
            StartCoroutine(NarrativeEnding());
            eventHappened = false;  

        }

        

		
	}

    IEnumerator NarrativeEnding()
    {
        audioControl.PlaySound(3);
        olive.OliveNod();
        yield return new WaitForSeconds(olive.GetAnimClipLength("nod") + 1.0f);
        olive.target = buttonPoint;
        olive.moving = true;
        while (Vector3.Magnitude(olive.transform.position - buttonPoint.position) > 0.1f)
            yield return null;
        olive.moving = false;
        yield return new WaitForSeconds(0.1f);
        olive.machine2 = true;
        nutmachine.permaActive = true;
        nutmachine.active = true;
        yield return new WaitForSeconds(1.3f);
        nutmachine.spawning = true;
        olive.machine2 = false;
        olive.target = adressPoint;
        olive.moving = true;
        while (Vector3.Magnitude(olive.transform.position - adressPoint.position) > 0.1f)
            yield return null;
        olive.moving = false;
        olive.approval = true;

        yield return new WaitForSeconds(olive.GetAnimClipLength("Approval"));
        olive.approval = false;
        yield return new WaitForSeconds(3.0f);
        audioControl.PlaySound(4);
        geysirTeleport.SetActive(true);
        yield return new WaitForSeconds(audioControl.GetClipLength(4));
        EndStage();
        StartCoroutine(CompleteStage(0.1f));
    }


    protected override IEnumerator CompleteStage(float delay)
    {
        manager.sixthStateComplete = true;
        manager.triggerAcheivements = true;
        yield return new WaitForSeconds(delay);
        manager.eventHappened = true;
        active = false;
    }

    public void EndStage()
    {
        StartCoroutine(CompleteStage(0));
        audioControl.StopAllSounds();
        audioControl.enabled = false;
    }

    public override void Initialize()
    {
        print("sixthstage intialized");
        active = true;
    }

}
