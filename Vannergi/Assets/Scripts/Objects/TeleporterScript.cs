using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleporterScript : MonoBehaviour
{
    public Transform teleportTarget;
    public Renderer teleporterShader;
    Material teleMat;
    public float animSpeed;
    public float alphaStandard;
    float alphaMod, speedMod;
    public bool teleporting;
    public bool inDam;
    public float teleportDelay;
    GameObject player;
    public Color c;
    public float highlightThickness;
    bool thickning;
    bool thinning;
    public bool firstTimeUsed;
    public int teleporterNr = 0;
    public GameManagement manager;
    public FirstStageManager firstManager;
    public SecondStageManager secondManger;
    public ThirdStageManager thirdManager;
    public ForthStageManager forthManager;
    public FifthStageManager fifthManager;
    public SeventhStageManager seventhManager;
    SixthStageManager sixthManager;
    bool narrativeEnded;
    bool animating;
    public SFXAudioControl SFX;
    public TeleporterScript nextTeleporter;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inDam = false;
        highlightThickness = 0.02f;
        thickning = true;
        firstManager = FindObjectOfType<FirstStageManager>();
        secondManger = FindObjectOfType<SecondStageManager>();
        thirdManager = FindObjectOfType<ThirdStageManager>();
        forthManager = FindObjectOfType<ForthStageManager>();
        fifthManager = FindObjectOfType<FifthStageManager>();
        sixthManager = FindObjectOfType<SixthStageManager>();
        seventhManager = FindObjectOfType<SeventhStageManager>();
        manager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        SFX = GameObject.Find("SFXAudio").GetComponent<SFXAudioControl>();
        teleMat = teleporterShader.material;
        alphaMod = alphaStandard;
        speedMod = animSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //Increases and decreases hightlight shaders line thickness to create a pulsing effect
        if (thickning)
            highlightThickness += 0.027f;
        if (thinning)
            highlightThickness -= 0.027f;

        if(animating)
        {
            animSpeed += Time.deltaTime/3;
            alphaMod -= Time.deltaTime/3;
            TeleportAnimation(speedMod, alphaMod);
        }
        else
        {
            TeleportAnimation(animSpeed, alphaStandard);
        }

        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().material.SetFloat("_Outline", highlightThickness);
        }

        //Teleports user and tells the game manager a potentially significant event has happened
        //This can be moved to an individual fucntion that can be called instead
        if (teleporting)
        {
            if (!firstTimeUsed)
            {
                if (teleporterNr == 0)
                {
                    teleporterNr = 0;
                    firstManager.eventHappened = true;
                    firstManager.teleportInstructionsComplete = true;
                    SFX.PlaySuccess();
                    print(" might be teleportert");
                }
                if (teleporterNr == 1)
                {
                    secondManger.CompletedStage();
                    inDam = true;
                    thirdManager.insideDam = true;
                    thirdManager.Initialize();

                }
                if (teleporterNr == 2)
                {
                    inDam = false;
                    thirdManager.insideDam = false;
                    thirdManager.CompletedStage();
                }
                if(teleporterNr == 3)
                {
                    thirdManager.insideDam = true;
                    forthManager.CompletedStage();
                    forthManager.EndStage();
                    fifthManager.TriggerDialog();
                    nextTeleporter.teleporterNr = 4;
                    nextTeleporter.firstTimeUsed = false;
                    nextTeleporter.teleportTarget = GameObject.Find("Teleport point Machine").transform;

                }
                if (teleporterNr == 4)
                {
                    print(" inside number 4");
                    fifthManager.EndStage();
                    sixthManager.eventHappened = true;
                    thirdManager.insideDam = false;
                    nextTeleporter.teleporterNr = 6;
                }

                firstTimeUsed = true;
            }

            if (teleporterNr == 5)
            {
                print(" inside number 5");
                sixthManager.EndStage();
                manager.geysirVisited = true;
                manager.triggerAcheivements = true;
                seventhManager.audioControl.StopAllSounds();
                seventhManager.PlayGeysir();
            }

            if (teleporterNr == 6)
            {
                sixthManager.EndStage();
                print(" inside number 6");
                manager.damRevisited = true;
                manager.triggerAcheivements = true;
                seventhManager.audioControl.StopAllSounds();
                seventhManager.PlayDam();
            }

            StartCoroutine(Teleport(teleportTarget, teleportDelay));
            teleporting = false;



        }

        if (highlightThickness > 0.2)
        {
            thickning = false;
            thinning = true;
        }
        if (highlightThickness < 0.057)
        {
            thickning = true;
            thinning = false;
        }

    }

    //Teleports player and enacts saft measures such as turning of the collider of the teleporter to ensure no duble activation
    IEnumerator Teleport(Transform target, float delay)
    {

        gameObject.GetComponent<Collider>().enabled = false;
        //StartCoroutine (FadeOutColor (delay));
        yield return new WaitForSeconds(delay);
        player.transform.position = target.position;
        //		StartCoroutine (FadeInColor (delay));
        gameObject.GetComponent<Collider>().enabled = true;

        //Works only when two teleporters exist

    }
    //Used for fade in and out of screen overlay for smooth transition experience
    IEnumerator FadeOutColor(float duration)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            //Color newColor = new Color (0, 0, 0, Mathf.Lerp(1.0f,0.0f, duration));
            //c = newColor;
            yield return null;
        }
    }

    IEnumerator FadeInColor(float duration)
    {
        for (float t = 1.0f; t > 0.0f; t -= Time.deltaTime / duration)
        {
            //Color newColor = new Color (0,0,0, Mathf.Lerp(0.0f,1.0f, duration));
            yield return null;
        }
    }

    public void TeleportAnimation(float speed, float alpha)
    {
        teleMat.SetFloat("_RotSpeed", speed);
        teleMat.SetFloat("_Cutoff", alpha);
    }

    public void ActivateTeleporter()
    {
        animating = true;
        StartCoroutine(TeleporterInUse(3.0f));
    }

    IEnumerator TeleporterInUse(float delay)
    {
        yield return new WaitForSeconds(delay);
        animating = false;
        alphaMod = alphaStandard;
        speedMod = animSpeed;
    }

    float AnimateAnimSpeed()
    {
        return 0;
    }
    
    float AnimateAnimAlpha()
    {
        return 0;
    }

}
