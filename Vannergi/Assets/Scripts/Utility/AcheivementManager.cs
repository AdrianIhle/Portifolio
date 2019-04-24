using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcheivementManager : Manager {

    public Button[] icons;
    public bool tutorialComplete;
    public bool damFixed;
    public bool beaverDamGone;
    public bool storyComplete;
    public bool geysirVisited;
    public bool damRevisited;
    public bool wrenchesCollected;
    public SFXAudioControl SFX;
    // Use this for initialization
    void Start () {
        icons = GetComponentsInChildren<Button>();
        SFX = GameObject.Find("SFXAudio").GetComponent<SFXAudioControl>();
        eventHappened = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (eventHappened)
        {
            print("achieve event");
            ManageIcons();
            eventHappened = false;
            SFX.PlayAchievementGet();
        }

    }

    void ManageIcons()
    {
        if (tutorialComplete)
            AcheivementComplete(0);
        if (damFixed)
            AcheivementComplete(1);
        if (beaverDamGone)
            AcheivementComplete(2);
        if (storyComplete)
            AcheivementComplete(3);
        if (geysirVisited)
            AcheivementComplete(4);
        if (damRevisited)
            AcheivementComplete(5);
        if (wrenchesCollected)
            AcheivementComplete(6);
    }

    void AcheivementComplete(int achievement)
    {
        ColorBlock b = icons[achievement].colors;
        b.colorMultiplier = 5.0f;
        icons[achievement].colors = b;
    }
}
