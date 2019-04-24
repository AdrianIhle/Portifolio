using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthStageManager : LocalManager {


    bool inspect;
    public Transform oliveTeleport, oliveMachine;
    // Update is called once per frame
    void Update() {
        if (eventHappened)
        {
            if (inspect)
            {                
                StartCoroutine(CompleteStage(audioControl.GetClipLength(11) + 1.0f));
                inspect = false;
            }
            else
            {
                audioControl.PlaySound(10);
            }
            eventHappened = false;
        }

        if (timerRequired && active)
        {
            ManageTimer();
        }

        if (Vector3.Magnitude(olive.transform.position - oliveTeleport.position) < 0.1f)
        {
            olive.transform.position = oliveMachine.position;
            olive.transform.rotation = oliveMachine.rotation;
            olive.moving = false;
            olive.onTheMove = false;

        }
    }

    public void TriggerDialog()
    {
        manager.managers[4].audioControl.StopAllSounds();
        audioControl.PlaySound(11);
        print("triggering dialog in 5th manager");
        inspect = true;
        eventHappened = true;
    }

    public void EndStage()
    {
        StartCoroutine(CompleteStage(0));
        audioControl.StopAllSounds();
        olive.transform.position = oliveMachine.position;
        olive.transform.rotation = oliveMachine.rotation;
        olive.moving = false;
        olive.onTheMove = false;
    }

    protected override IEnumerator CompleteStage(float delay)
    {
        manager.fifthStateComplete = true;
        active = false;
        yield return new WaitForSeconds(delay);
        manager.eventHappened = true;
        audioControl.StopAllCoroutines();
        audioControl.StopAllSounds();
        StopAllCoroutines();
    }

    IEnumerator OliveControls()
    {
        olive.OliveNod();
        yield return new WaitForSeconds(audioControl.GetClipLength(11)*0.80f);
        olive.target = oliveTeleport;
        olive.moving = true;
    }

    public override void Initialize()
    {
        active = true;
        eventHappened = true;
    }

}
