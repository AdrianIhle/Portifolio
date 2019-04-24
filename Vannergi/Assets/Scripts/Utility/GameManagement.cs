using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : Manager {

    public enum GameState
    {
        State0,
        State1,
        State2,
        State3,
        State4,
        State5,
        State6,
        State7,
    }

    public LocalManager Local1, Local2, Local3, Local4, Local5, Local6, Local7;
    public List<LocalManager> managers  = new List<LocalManager>();
    public bool firstStateComplete, secondStateComplete, thirdStateComplete, forthStateComplete, fifthStateComplete, sixthStateComplete, seventhStateComplete;
    public bool geysirVisited;
    public bool damRevisited;
    public bool wrenchesCollected;
    public bool triggerAcheivements;
    public LocalManager currentManager;
    public GameState currentState;
    public AcheivementManager achievements;

	// Use this for initialization
	void Start () {
        currentState = GameState.State1;
        eventHappened = true;

        Local1 = FindObjectOfType<FirstStageManager>();
        managers.Add(Local1);
        Local2 = FindObjectOfType<SecondStageManager>();
        managers.Add(Local2);
        Local3 = FindObjectOfType<ThirdStageManager>();
        managers.Add(Local3);
        Local4 = FindObjectOfType<ForthStageManager>();
        managers.Add(Local4);
        Local5 = FindObjectOfType<FifthStageManager>();
        managers.Add(Local5);
        Local6 = FindObjectOfType<SixthStageManager>();
        managers.Add(Local6);
        Local7 = FindObjectOfType<SeventhStageManager>();
        managers.Add(Local7);
    }
	
	// Update is called once per frame
	void Update () {

        ControlState();
        if (eventHappened)
        {
            print("game manager event happened at state: " + currentState);
            switch(currentState)
            {
                case GameState.State0:
                    currentManager = null;
                    DeactivateAllLocalManagers();
                    break;
                case GameState.State1:
                    currentManager = (FirstStageManager) Local1;
                    StartCoroutine(StartNext(0.5f));
                    break;
                case GameState.State2:
                    currentManager = (SecondStageManager) Local2;
                    StartCoroutine(StartNext(0.5f));
                    break;
                case GameState.State3:
                    currentManager = (ThirdStageManager) Local3;
                    //StartCoroutine(StartNext(0.5f));
                    break;
                case GameState.State4:
                    currentManager = (ForthStageManager)Local4;
                    StartCoroutine(StartNext(0.5f));
                    break;
                case GameState.State5:
                    currentManager = (FifthStageManager)Local5;
                    StartCoroutine(StartNext(0.5f));
                    break;
                case GameState.State6:
                    currentManager = (SixthStageManager)Local6;
                    StartCoroutine(StartNext(0.5f));
                    break;
                case GameState.State7:
                    currentManager = (SeventhStageManager)Local7;
                    StartCoroutine(StartNext(0.5f));
  

                    break;
                default:
                    break;
            }

            eventHappened = false;
        }

        if (triggerAcheivements)
        {
            print("achievement triggered");
            ControlAcheivements();
            triggerAcheivements = false;
        }


    }

    void ControlState()
    {
        if (!firstStateComplete && !secondStateComplete && !thirdStateComplete && !forthStateComplete && !fifthStateComplete && !sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State1;
        }
        else if (firstStateComplete && !secondStateComplete && !thirdStateComplete && !forthStateComplete && !fifthStateComplete && !sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State2;
        }
        else if (firstStateComplete && secondStateComplete && !thirdStateComplete && !forthStateComplete && !fifthStateComplete && !sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State3;
        }
        else if (firstStateComplete && secondStateComplete && thirdStateComplete && !forthStateComplete && !fifthStateComplete && !sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State4;
        }
        else if (firstStateComplete && secondStateComplete && thirdStateComplete && forthStateComplete && !fifthStateComplete && !sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State5;
        }
        else if (firstStateComplete && secondStateComplete && thirdStateComplete && forthStateComplete && fifthStateComplete && !sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State6;
        }
        else if (firstStateComplete && secondStateComplete && thirdStateComplete && forthStateComplete && fifthStateComplete && sixthStateComplete && !seventhStateComplete)
        {
            currentState = GameState.State7;
        }
        else if (firstStateComplete && secondStateComplete && thirdStateComplete && !forthStateComplete && !fifthStateComplete && !sixthStateComplete && seventhStateComplete)
        {
            currentState = GameState.State0;
        }
    }

    void ControlAcheivements()
    {
        if (firstStateComplete)
            achievements.tutorialComplete = true;
        if (thirdStateComplete)
            achievements.damFixed = true;
        if (forthStateComplete)
            achievements.beaverDamGone = true;
        if (sixthStateComplete)
            achievements.storyComplete = true;
        if (geysirVisited)
            achievements.geysirVisited = true;
        if (damRevisited)
            achievements.damRevisited = true;
        if (wrenchesCollected)
            achievements.wrenchesCollected = true;

        achievements.eventHappened = true;
    }

    IEnumerator StartNext(float delay)
    {
        print("intialize next");
        yield return new WaitForSeconds(delay);
        currentManager.Initialize();
    }

    public void SetState(GameState state)
    {
        currentState = state;
    }

    public void SilenceAllManagers()
    {
        foreach (LocalManager m in managers)
            m.audioControl.StopAllSounds();
        StopAllCoroutines();
    }

    void DeactivateAllLocalManagers()
    {
        foreach (LocalManager l in managers)
            l.gameObject.SetActive(false);
    }
}
