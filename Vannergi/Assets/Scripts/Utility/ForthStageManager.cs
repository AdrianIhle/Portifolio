using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForthStageManager : LocalManager {

    [SerializeField]
    bool damExists = true;
    public bool intro;
    public bool firstInstruction;
    public bool shoutLouder;
    public bool secondInstruction;
    public bool moveOlive;
    public Transform oliveTeleporter, oliveInDam;
    public GameObject beaverDam;
    public WaterScript river;
    public WaterScript reserviour;
	// Update is called once per frame
	void Update () {
        if(eventHappened)
        {
            print("in forth event");
             if(damExists && intro && !firstInstruction )
            {
                nextTeleporter.SetActive(false);
                print("forth intro");
                StartCoroutine(OliveSequence());
                intro = false;
            }
            else if(damExists && !intro && firstInstruction)
            {
                if (!shoutLouder)
                    audioControl.PlaySound(1);
                else
                    audioControl.PlaySound(2);
                print("instructions");
                shoutLouder = true;
                olive.OliveShout();
            }
             else if (secondInstruction && !audioControl.IsPlaying())
                audioControl.PlaySound(4);

            eventHappened = false;

        }

        if (timerRequired && active)
        {
            ManageTimer();
        }

        if (Vector3.Magnitude(olive.transform.position - oliveTeleporter.position) < 0.1f)
        {
            olive.transform.position = oliveInDam.position;
            olive.transform.rotation = oliveInDam.rotation;
            olive.transform.rotation = oliveInDam.rotation;
            olive.moving = false;
            olive.onTheMove = false;

        }
    }


    public override void Initialize()
    {
        active = true;
        damExists = true;
        intro = true;
        manager.managers[2].active = false;
        manager.managers[2].audioControl.StopAllSounds();
        manager.managers[2].StopAllCoroutines();
        eventHappened = true;
        olive.moving = false;
        olive.onTheMove = false;
        olive.running = false;

    }

    IEnumerator DelayedFirstInstruct(float delay)
    {
        yield return new WaitForSeconds(delay);
        firstInstruction = true;
        eventHappened = true;
        olive.pointForward = true;
    }

    protected override IEnumerator CompleteStage(float delay)
    {
        manager.forthStateComplete = true;
        manager.triggerAcheivements = true;
        active = false;
        yield return new WaitForSeconds(delay);
        manager.eventHappened = true;
    }

    public void EndStage()
    {
        StartCoroutine(CompleteStage(0));
        audioControl.StopAllSounds();
    }

    public void DamGone()
    {
        shoutLouder = false;
        damExists = false;
        secondInstruction = true;
        eventHappened = true;
        olive.pointForward = false;
        StartCoroutine(DeleteDam());
        reserviour.StartCoroutine(reserviour.WaterRise());
        river.StartCoroutine(river.WaterRise());
        GameObject.Find("WaterAudio").SetActive(true);
        nextTeleporter.SetActive(true);
    }

    public void CompletedStage()
    {
        active = false;
        StartCoroutine(CompleteStage(0.5f));
    }

    void OliveToTeleport()
    {
        olive.target = oliveTeleporter;
        olive.moving = true;
    }

    IEnumerator DeleteDam()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(beaverDam);
    }

    IEnumerator OliveSequence()
    {
        audioControl.PlaySound(0);
        olive.OliveShakeHead();
        StartCoroutine(DelayedFirstInstruct(audioControl.GetClipLength(0) + 0.75f));
        while (damExists)
            yield return null;
        DamGone();
        audioControl.PlaySound(3);
        olive.OliveCheer();
        yield return new WaitForSeconds(2.0f);
        OliveToTeleport();
    }
}
