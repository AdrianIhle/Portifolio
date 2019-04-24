using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageManager : LocalManager {

    public bool playerArrived;
    public bool introPlayed;
    public bool machineBroken;
    public bool playerInArea;
    public bool moveToDam;

    bool crRunning;

    public NutOMatic nutmachine;
    public Transform firstPos;
    public Transform secondPos;
    public Transform thirdPos;
    public Transform firstPointInPath;
    public Transform entryDam;
    bool moveToFirst;
    bool moveToSecond;
    bool moveToThird;

    public WaterScript river;
    // Use this for initialization
	
	// Update is called once per frame
	void Update () {

        if (eventHappened && active)
        {
            if (!crRunning)
                StartCoroutine(OliveAndMachine());
            eventHappened = false;

            if(playerArrived && machineBroken && introPlayed)
            {
                manager.secondStateComplete = true;
                manager.eventHappened = true;
                CompletedStage();
            }

        }

        if (timerRequired && active)
        {
            ManageTimer();
        }

        if (active)
        {
            if (moveToFirst)
            {
                //olive.moving = true;
                olive.MoveTo(firstPos);
                if (Vector3.Magnitude(olive.transform.position - firstPos.position) == 0.0f)
                {
                    moveToFirst = false;
                    olive.moving = false;
                }
            }
            else if (moveToSecond)
            {
                // olive.moving = true;
                olive.MoveTo(secondPos);
                if (Vector3.Magnitude(olive.transform.position - secondPos.position) == 0.0f)
                {
                    moveToSecond = false;
                    olive.moving = false;
                    olive.transform.rotation = secondPos.rotation;
                }
            }
            else if (moveToThird)
            {
                //olive.moving = true;
                olive.MoveTo(thirdPos);
                if (Vector3.Magnitude(olive.transform.position - thirdPos.position) == 0.0f)
                {
                    moveToThird = false;
                    olive.moving = false;
                    olive.transform.rotation = thirdPos.rotation;
                }
            }
            else if (moveToDam)
            {
                olive.MoveTo(firstPointInPath);
                nextTeleporter.gameObject.SetActive(true);
                if (Vector3.Magnitude(olive.transform.position - firstPointInPath.position) == 0.0f)
                {
                    moveToDam = false;
                }
            }
        }
    }

    public override void Initialize()
    {
        active = true;
        playerArrived = true;

        eventHappened = true;
    }

    protected override IEnumerator CompleteStage(float delay)
    {
        manager.secondStateComplete = true;
        olive.ClearAllBools();
        olive.target = entryDam;
        olive.transform.position = entryDam.position;
        yield return new WaitForSeconds(delay);
        manager.eventHappened = true;
        active = false;
    }

    IEnumerator IntroEnded(float delay)
    {
        yield return new WaitForSeconds(delay);
        introPlayed = true;
        eventHappened = true;
    }

    IEnumerator MachineBreaking(float delay)
    {
        yield return new WaitForSeconds(delay);
        machineBroken = true;
        eventHappened = true;
        river.StartCoroutine(river.WaterSink());
    }

    IEnumerator OliveAndMachine()
    {
        nextTeleporter.gameObject.SetActive(false);
        crRunning = true;
        audioControl.PlaySound(0);
        olive.OliveWave();
        yield return new WaitForSeconds(audioControl.GetClipLength(0));
        moveToFirst = true;
        while (Vector3.Magnitude(olive.transform.position - firstPos.position) > 0.1f)
            yield return null;
        olive.wave = false;
        olive.OliveMachineAnimation1();
        yield return new WaitForSeconds(olive.GetAnimClipLength("Maskin_01") +1.0f);
        moveToSecond = true;
        while (Vector3.Magnitude(olive.transform.position - secondPos.position) > 0.1f)
            yield return null;
        olive.OliveMachineAnimation2();
        yield return new WaitForSeconds(olive.GetAnimClipLength("machine_olive_02")/* + 0.1f*/);
        olive.OliveMachineAngry();
        StartCoroutine(MachineBreaking(audioControl.GetClipLength(1) + 0.75f));
        nutmachine.active = false;
        GameObject.Find("WaterAudio").SetActive(false);
        yield return new WaitForSeconds(olive.GetAnimClipLength("angry_at_machine") + 1.0f);
        moveToThird = true;
        while (Vector3.Magnitude(olive.transform.position - thirdPos.position) > 0.1f)
            yield return null;
        olive.OliveSurprised();
        audioControl.PlaySound(1);
        yield return new WaitForSeconds(audioControl.GetClipLength(1)*0.66f);
        moveToDam = true;
        audioControl.PlaySound(2);
    }

    public void CompletedStage()
    {
        active = false;
        StartCoroutine(CompleteStage(0.5f));
        audioControl.StopAllSounds();
        audioControl.StopAllCoroutines();

    }

}
