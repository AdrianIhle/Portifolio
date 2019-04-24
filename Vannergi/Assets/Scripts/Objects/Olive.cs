using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olive : MonoBehaviour {

    // how this script works
    /*
     Olive has 5 avatar masks, one for the body (that does not include the head)
     one for the head (not including anything else)
     one for each arm 
     and one for the tail (not including anything else)
     The body mask is put on the base layer, then a new layer for the head, then for the arms(left then right)
     then for the tail, and finally a layer with no mask that is meant to override all the others. This is done so one
     does not need to trigger all the individual parts of an animation seperately.

     Each layer, not counting base layer, has an empty state as its entry point and default state. This means that unless told otherwise
     the animation played will be that of the idle animation of the base layer. This is done to have a high level of customization  
     The head, tail and Full body animation layer each have their own bools that allow them to exit the empty default state and enter
     their own animations through an idle animation. 
         */

    public bool moving;
    public bool running;
    public float speed;
    public bool pointing;
    public bool pointLeft;
    public bool pointRight;
    public bool pointForward;
    public bool machine1;
    public bool machine2;
    public bool machineAngry;
    public bool tilt;
    public bool wink;
    public bool wave;
    public bool surprised;
    public bool nod;
    public bool shakeHead;
    public bool approval;
    public bool shout;
    public bool emoteBody;
    public bool emoteTail;
    public bool emoteFace;
    public bool fullAnimation;
    Animator anim;
    AnimationClip[] clips;
    public bool onTheMove;
    bool firstPatrol = true;
    float lastAngle;
    RuntimeAnimatorController rac;
    public Transform target;

    AnimatorClipInfo[] clipInfo;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        rac = anim.runtimeAnimatorController;
        if (rac != null)
        {
            print("acquired RAC");
            clips = new AnimationClip[rac.animationClips.Length];
        }
        print("rac length " + rac.animationClips.Length.ToString());

        for (int i = 0; i < rac.animationClips.Length; i++)
        {
            if (rac.animationClips[i] != null)
            {
                print("rac clip name " + rac.animationClips[i].name);
                clips[i] = rac.animationClips[i];
            }
            
        }
        
    }

    // Update is called once per frame
    void Update() {
        SetAnimBools();

        if (moving)
        {
            print("instide olvie move");
            MoveTo(target);
            onTheMove = true;
        }
        else
            onTheMove = false;
    }

    private void LateUpdate()
    {
        lastAngle = transform.rotation.eulerAngles.y;
    }

    void SetAnimBools()
    {
        anim.SetBool("moving", moving);
        anim.SetBool("running", running);
        anim.SetBool("pointing", pointing);
        anim.SetBool("machine 1", machine1);
        anim.SetBool("machine 2", machine2);
        anim.SetBool("tilt", tilt);
        anim.SetBool("pointRight", pointRight);
        anim.SetBool("pointLeft", pointLeft);
        anim.SetBool("pointForward", pointForward);
        anim.SetBool("machine angry", machineAngry);
        anim.SetBool("wink", wink);
        anim.SetBool("wave", wave);
        anim.SetBool("surprised", surprised);
        anim.SetBool("nod", nod);
        anim.SetBool("shake head", shakeHead);
        anim.SetBool("approval", approval);
        anim.SetBool("emote body", emoteBody);
        anim.SetBool("emote tail", emoteTail);
        anim.SetBool("shout", shout);
        anim.SetBool("full body", fullAnimation);
        anim.SetBool("emote face", emoteFace);
    }

    public void MoveTo(Transform t)
    {
        print("olive should mvoe" + t.name);
        Quaternion q = Quaternion.LookRotation(t.position - transform.position);
        if (Mathf.Abs(Vector3.Distance(transform.position, t.position)) > 1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 5);
        }


        if (!onTheMove)
        {
            if (RotationStopped(transform.rotation.eulerAngles.y, lastAngle))
            {
                transform.position = Vector3.Lerp(transform.position, t.position, 1 / (Vector3.Distance(transform.position, t.position) / speed));
            }
        }
        else
            transform.position = Vector3.Lerp(transform.position, t.position, 1 / (Vector3.Distance(transform.position, t.position) / speed));
    }

    bool RotationStopped(float currentAngle, float lastAngle)
    {
        if (currentAngle == lastAngle)
            return true;
        else
            return false;
    }

    void AlertObservers(string message)
    {
        if(message.Equals ("WaveEnded"))
        {

        }
        else if(message.Equals("Machine1Ended"))
        {

        }
        else if(message.Equals("Machine2ended"))
        {

        }
    }

    public void OliveShout()
    {
        fullAnimation = true;
        shout = true;
        StartCoroutine(ClearAfterClip(SearchForClip("shout").length));
    }

    public void OliveGreet()
    {
        fullAnimation = true;
        wave = true;
        StartCoroutine(ClearAfterClip(SearchForClip("wave").length));
    }

    public void OliveCheer()
    {
        fullAnimation = true;
        approval = true;
        StartCoroutine(ClearAfterClip(SearchForClip("Approval").length));

    }

    public void OliveWink()
    {
        fullAnimation = true;
        wink = true;
        StartCoroutine(ClearAfterClip(SearchForClip("wink").length));
    }

    public void OliveNod()
    {
        fullAnimation = true;
        nod = true;
        StartCoroutine(ClearAfterClip(SearchForClip("nod").length));
    }

    public void OliveSurprised()
    {
        fullAnimation = true;
        surprised = true;
        StartCoroutine(ClearAfterClip(GetAnimClipLength("surprise")));
    }

    public void OliveShakeHead()
    {
        fullAnimation = true;
        shakeHead = true;
        StartCoroutine(ClearAfterClip(SearchForClip("Shake head").length));
    }

    public void OliveTiltHead()
    {
        fullAnimation = true;
        tilt = true;
        StartCoroutine(ClearAfterClip(SearchForClip("tilt head").length));
    }

    public void OliveStartWalk()
    {
        fullAnimation = true;
        moving = true;
    }

    public void OliveStopWalk()
    {
        fullAnimation = false;
        moving = false;
    }

    public void OliveStartRun()
    {
        fullAnimation = true;
        moving = true;
        running = true;
    }

    public void OliveStopRun()
    {
        fullAnimation = false;
        moving = false;
        running = true;
    }

    public void OlivePointTowards(Transform target, int direction)
    {
        fullAnimation = true;
        pointing = true;
        if (direction == 0)
            pointForward = true;
        else if (direction == 1)
            pointRight = true;
        else if (direction == 2)
            pointLeft = true;

        transform.LookAt(target);

    }

    public void OliveLook(Transform target)
    {
        transform.LookAt(target);
    }

    public void OliveMachineAnimation1()
    {
        fullAnimation = true;
        machine1 = true;
        StartCoroutine(ClearAfterClip(GetAnimClipLength("Maskin_01")));
    }

    public void OliveMachineAnimation2()
    {
        fullAnimation = true;
        machine2 = true;
        StartCoroutine(ClearAfterClip(GetAnimClipLength("machine_olive_02" /*+ 0.1f*/)));
    }

    public void OliveMachineAngry()
    {
        fullAnimation = true;
        machine2 = true;
        machineAngry = true;
        StartCoroutine(ClearAfterClip(GetAnimClipLength("angry_at_machine")));
    }

    public void OliveWave()
    {
        fullAnimation = true;
        wave = true;
        StartCoroutine(ClearAfterClip(GetAnimClipLength("wave")+0.10f));
    }

    public void OliveWondering()
    {
        tilt = true;
        emoteTail = true;
        surprised = true;
    }

    public void OlivePatrol(Transform t, Transform p)
    {
        if(firstPatrol)
        {
            target = t;
            firstPatrol = false;
        }
        moving = true;
        if (Vector3.Magnitude(transform.position - p.position) == 0.0f)
        {
            target = t;
        }
         else if (Vector3.Magnitude(transform.position - t.position) == 0.0f)
        {
            target = p;
        }
    }

    AnimationClip SearchForClip(string name)
    {
        AnimationClip clip = null;
        foreach(AnimationClip c in clips)
        {
            if (c.name == name)
                clip = c;

        }

        return clip;
    }

    public float GetAnimClipLength(string clipName)
    {
        //print("getting clip length for " + clipName);
        return SearchForClip(clipName).length;
    }

    IEnumerator ClearAfterClip(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearAllBools();
    }

    public void ClearAllBools()
    {
         moving        = false;
         running       = false;
         pointing      = false;
         pointLeft     = false;
         pointRight    = false;
         pointForward  = false;
         machine1      = false;
         machine2      = false;
         machineAngry  = false;
         tilt          = false;
         wink          = false;
         wave          = false;
         surprised     = false;
         nod           = false;
         shakeHead     = false;
         approval      = false;
         shout         = false;
         emoteBody     = false;
         emoteTail     = false;
         emoteFace     = false;
         fullAnimation = false;

    }
}
