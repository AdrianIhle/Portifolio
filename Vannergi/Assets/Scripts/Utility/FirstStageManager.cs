using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageManager : LocalManager {

    public bool initiate;
    public bool interactionInstructionsComplete;
    public bool soundInstrcutionsComplete;
    public bool teleportInstructionsComplete;

    public GameObject cube;
    public GameObject ball;
    public GameObject teleporter, oliveTeleport, smartMachine, transformer;
    public GameObject redLight;
    public GameObject greenLight;
    public ObjectLift objectLift;
    public Transform oliveMachinePos;

    public bool testWave;

    public bool firstBackUp, secondBackup, thirdBackUp;
    // Use this for initialization
    private new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate () {


        if (eventHappened && active)
        {
            print("init bool " + initiate);
            if(initiate)
            {
                StartCoroutine(DeactivateObjects(0.01f));
                audioControl.PlaySound(0);
                olive.OliveGreet();
                print(" first intiate");
                initiate = false;
                StartCoroutine(DelayedEventCall(audioControl.GetClipLength(0)+ 0.2f));
            }

            else if(provideAcknowledgement)
            {
                print("acknowledgement");

                olive.OliveLook(transform);
                StopAllCoroutines();

                provideAcknowledgement = false;

                if (interactionInstructionsComplete && !soundInstrcutionsComplete && !teleportInstructionsComplete)
                {
                    audioControl.PlaySound(3);
                    StartCoroutine(DelayedEventCall(audioControl.GetClipLength(3) + 0.2f));
                    olive.OliveCheer();
                    redLight.SetActive(false);
                    greenLight.SetActive(true);
                }
                else if (interactionInstructionsComplete && soundInstrcutionsComplete && !teleportInstructionsComplete)
                {
                    audioControl.PlaySound(6);
                    StartCoroutine(DelayedEventCall(audioControl.GetClipLength(6) + 0.2f));
                    olive.OliveCheer();
                }
            }
            else
            {
                if (!interactionInstructionsComplete && !soundInstrcutionsComplete && !teleportInstructionsComplete)
                {
                    if (!firstBackUp)
                    {
                        StopCoroutine("DelayedEventCall");
                        audioControl.PlaySound(1);
                        print("play first instruction");
                        firstBackUp = true;
                        StartCoroutine(InteractionInstructionAnim(5.0f, transformer.transform)); //need to replace secondary target once available in build
                    }
                    else
                    {
                        audioControl.PlaySound(1);
                        StartCoroutine(InteractionInstructionAnim(5.0f, transformer.transform)); //need to replace secondary target once available in build
                    }
                }
                else if (interactionInstructionsComplete && !soundInstrcutionsComplete && !teleportInstructionsComplete)
                {
                    if (!secondBackup)
                    {
                        StartCoroutine(objectLift.LiftBall(2.5f));
                        audioControl.PlaySound(4);
                        print("play second instruction");
                        secondBackup = true;
                        StartCoroutine(DelayedShoutAnim(5.0f));
                    }
                    else
                    {
                        audioControl.PlaySound(5);
                        olive.OliveShout();
                    }
                }
                else if (interactionInstructionsComplete && soundInstrcutionsComplete && !teleportInstructionsComplete)
                {
                    if (!thirdBackUp)
                    {
                        teleporter.GetComponent<CapsuleCollider>().enabled = true;
                       // teleporter.GetComponentInChildren<Animator>().SetBool("isAnimating", true);
                        audioControl.PlaySound(7);
                        print("play third instruction");
                        thirdBackUp = true;
                        StartCoroutine(OliveToTeleport(1.0f));
                    }
                    else
                    {
                        audioControl.PlaySound(8);
                    }
                }
                else if (interactionInstructionsComplete && soundInstrcutionsComplete && teleportInstructionsComplete)
                {
                    audioControl.PlaySound(9);
                    StartCoroutine(CompleteStage(audioControl.GetClipLength(9) + 0.2f));
                    print("play teleport completion");

                }
            }
            eventHappened = false;
        }


        if(timerRequired && active)
        {
            ManageTimer();
        }

    }

    public override void Initialize()
    {
        active = true;
        initiate = true;
        eventHappened = true;
    }

    protected override IEnumerator CompleteStage(float delay)
    {
        print("completing first stage");
        manager.firstStateComplete = true;
        manager.triggerAcheivements = true;
        yield return new WaitForSeconds(delay);
        manager.eventHappened = true;
        active = false;
    }

    IEnumerator DeactivateObjects(float delay)
    {
        yield return new WaitForSeconds(delay);
        ball.SetActive(false);
        teleporter.GetComponent<Collider>().enabled = false;
    }

    IEnumerator DelayedShoutAnim(float delay)
    {
        yield return new WaitForSeconds(delay);
        olive.OliveShout();
    }

    IEnumerator InteractionInstructionAnim(float delay, Transform secondTarget)
    {
        olive.OlivePointTowards(cube.transform, 0);
        print("point cube");
        yield return new WaitForSeconds(delay);
        olive.OlivePointTowards(secondTarget, 0);
        print("point telep");
    }

    IEnumerator OliveToTeleport(float delay)
    {
        olive.OliveCheer();
        yield return new WaitForSeconds(olive.GetAnimClipLength("Approval") +1.0f);
        olive.target = oliveTeleport.transform;
        olive.OliveStartRun();

        while (Vector3.Magnitude(olive.transform.position - oliveTeleport.transform.position) > 0.1f)
            yield return null;
        
            olive.OliveStopRun();
            teleporter.GetComponent<TeleporterScript>().ActivateTeleporter();

            yield return new WaitForSeconds(delay);
            olive.gameObject.SetActive(false);
            OliveToMachine();
   }

    void OliveToMachine()
    {
        print("olive teleported");
        olive.transform.position = oliveMachinePos.position;
        olive.transform.rotation = oliveMachinePos.rotation;
        olive.gameObject.SetActive(true);
    }
}
