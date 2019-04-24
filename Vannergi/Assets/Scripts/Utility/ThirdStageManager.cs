using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStageManager : LocalManager {

    public bool shaftNotInPlace = true;
    public bool tubeNotInPlace = true;
    public bool turbineOffline = true;
    public bool insideDam;
    public bool firstTime = true;
    public int ackNr = 1;
    public bool shaftBackUp, pipeBackUp;
    public bool damDone;
    public bool patrolling;
    public Transform pPoint1;
    public Transform pPoint2;
    public Transform Turbine;
    public Transform Shaft;
    public Transform Pipe;

    public Transform firstPath, secondPath, thirdPath, teleporter, oliveTopOfDam;
    public bool shouldMove;
    bool moveOlive;
    // Use this for initialization


	// Update is called once per frame
	void Update () {

        if (eventHappened)
        {

            if (!damDone)
            {
                if (!firstTime)
                {
                    nextTeleporter.SetActive(false);
                    firstTime = true;
                    audioControl.PlaySound(0);
                    StartCoroutine(DelayedEventCall(audioControl.GetClipLength(0) + 0.2f));
                    print("dam first time");
                    olive.OliveWondering();
                    secondPath.parent.gameObject.SetActive(true);
                    olive.onTheMove = false;
                    olive.moving = true;
                }
                else if (provideAcknowledgement)
                {
                    print("acknowledgement " + ackNr);
                    switch (ackNr)
                    {
                        case 1:
                            audioControl.PlaySound(2);
                            StartCoroutine(DelayedEventCall(audioControl.GetClipLength(2) + 0.2f));
                            break;
                        case 2:
                          StartCoroutine(DelayedEventCall(0.2f));
                            thirdPath.parent.gameObject.SetActive(true);
                            break;
                        case 3:
                            StartCoroutine(DelayedEventCall(0.2f));
                            break;
                        default:
                            break;     
                    }
                    ackNr++;
                    provideAcknowledgement = false;
                    olive.OliveCheer();

                }
                else if (shaftNotInPlace && turbineOffline && tubeNotInPlace)
                {
                    olive.OlivePointTowards(Turbine, 0);
                    manager.SilenceAllManagers();
                    audioControl.PlaySound(1);
                    StopAllCoroutines();
                    print("in dam first instruct");
                    secondPath.parent.gameObject.SetActive(true);
                }
                else if (shaftNotInPlace && !turbineOffline && tubeNotInPlace)
                {
                    print("in dam second instruct");
                    if (!shaftBackUp)
                    {
                        audioControl.PlaySound(4);
                        shaftBackUp = true;
                        Shaft.GetComponent<Collider>().enabled = true;
                        OliveMove(secondPath);
                    }
                    else
                        audioControl.PlaySound(5);
                }
                else if (!shaftNotInPlace && !turbineOffline && tubeNotInPlace )
                {
                    secondPath.parent.gameObject.SetActive(false);
                    thirdPath.parent.gameObject.SetActive(true);
                    shouldMove = true;
                    StopAllCoroutines();
                    print("in dam third instruct");
                    if (!pipeBackUp)
                    {
                        OliveMove(thirdPath);
                        audioControl.PlaySound(7);
                        pipeBackUp = true;
                    }
                    else
                        audioControl.PlaySound(8);

                }
                else if (!shaftNotInPlace && !turbineOffline && !tubeNotInPlace)
                {
                    nextTeleporter.SetActive(true);
                    audioControl.PlaySound(9);
                    print("in dam forth instruct");
                    damDone = true;
                    StartCoroutine(DelayedEventCall(audioControl.GetClipLength(9) + 0.75f));
                    CheerThenWonder();
                    StartCoroutine(OliveToTeleport(audioControl.GetClipLength(9) * 0.66f));
                }
            }
            else if(!audioControl.IsPlaying())
            {
                audioControl.PlaySound(10);
            }

            eventHappened = false;
        }

        if (timerRequired && active)
        {
            ManageTimer();
        }

        if (active)
        {
            if (Vector3.Magnitude(olive.transform.position - olive.target.position) > 0.1f && shouldMove)
                olive.moving = true;


            if (Vector3.Magnitude(olive.transform.position - teleporter.position) < 0.1f)
            {
                olive.transform.position = oliveTopOfDam.position;
                olive.transform.rotation = oliveTopOfDam.rotation;
               shouldMove = false;
               olive.moving = false;
               olive.onTheMove = false;
            }
        }

    }

    IEnumerator OliveToTeleport(float delay)
    {
        yield return new WaitForSeconds(delay);
        OliveMove(teleporter);
        shouldMove = true;
    }
    
    public override void Initialize()
    {
        active = true;
        eventHappened = true;
        olive.target = firstPath;
        olive.moving = true;
        print("third engaged");
        manager.managers[1].active = false;
        manager.managers[1].audioControl.StopAllSounds();
        manager.managers[1].audioControl.StopAllCoroutines();
        secondPath.parent.gameObject.SetActive(false);
        thirdPath.parent.gameObject.SetActive(false);
    }

    protected override IEnumerator CompleteStage(float delay)
    {
        manager.thirdStateComplete = true;
        manager.triggerAcheivements = true;
        active = false;
        yield return new WaitForSeconds(delay);
        manager.eventHappened = true;
        StopAllCoroutines();
        audioControl.StopAllSounds();
    }

    public void CompletedStage()
    {
        active = false;
        StartCoroutine(CompleteStage(0.5f));
        thirdPath.parent.gameObject.SetActive(false);
        olive.transform.position = oliveTopOfDam.position;
        olive.transform.rotation = oliveTopOfDam.rotation;
        shouldMove = false;
        olive.moving = false;
        olive.onTheMove = false;
    }

    IEnumerator CheerThenWonder()
    {
        olive.OliveCheer();
        yield return new WaitForSeconds(olive.GetAnimClipLength("Approval"));
        olive.OliveWondering();
        yield return new WaitForSeconds(olive.GetAnimClipLength("tilt head"));
    }

    void OliveMove(Transform t)
    {
        olive.target = t;
        olive.moving = true;
    }




}
