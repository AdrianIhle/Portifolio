using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalManager : Manager {

    public List<IEnumerator> CoRoutesRunning = new List<IEnumerator>();
    public AudioObject audioControl;
    public GameManagement manager;
    public bool provideAcknowledgement;
    public bool timerRequired;
    public bool active;
    public float timerThreshold;
    public float timer;
    public GameObject nextTeleporter;
    public enum Language
    {
        Norwegian,
        English,
    }
    Language currentLanguage;
    AudioObject [] dialogs;


    // Use this for initialization
    protected void Start()
    {
        base.Start();
        manager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        dialogs = GetComponentsInChildren<AudioObject>();
        currentLanguage = GameObject.FindObjectOfType<LanguageSelection>().language;
        switch (currentLanguage)
        {
            case Language.Norwegian:
                foreach(AudioObject a in dialogs)
                {
                    if(a.tag == "Norwegian")
                    {
                        audioControl = a;
                        break;
                    }
                }
                break;
            case Language.English:
                foreach (AudioObject a in dialogs)
                {
                    if (a.tag == "English")
                    {
                        audioControl = a;
                        break;
                    }
                }
                break;
            default:
                print("could not find language " + currentLanguage.ToString() + " in " + this.name + ". Attempting Fallback");
                foreach (AudioObject a in dialogs)
                {
                    if (a.tag == "Norwegian")
                    {
                        audioControl = a;
                        break;
                    }
                }
                break;
        }

        if(audioControl == null)
        {
            print("could not find sound packs");
        }
    }

    // Update is called once per frame
    void Update () {

		
	}

    public virtual void Initialize()
    {
        eventHappened = true;
        print("intializing manager at " + gameObject.name);
    }

     protected IEnumerator PlayAcknowledgePlay(int firstClipNr, int secondClipNr, float delay)
    {
        print("in place acknowledge");
        audioControl.PlaySound(firstClipNr);
        yield return new WaitForSeconds(delay);
        audioControl.PlaySound(secondClipNr);
    }

    protected virtual IEnumerator CompleteStage(float delay)
    {
        delay = 0.1f;
        print("virtual completion happening");
        yield return new WaitForSeconds(delay);
    }

    protected bool TimeIsUp()
    {
        if (timer > timerThreshold)
            return true;
        else
            return false;
    }

    protected void ManageTimer()
    {
        if (!audioControl.IsPlaying())
            timer += Time.deltaTime;
        else
            timer = 0.0f;

        if (TimeIsUp())
            eventHappened = true;
    }
}
