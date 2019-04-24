using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeysirAnimScript : MonoBehaviour {

    public bool active;
    public bool inLoop;
    public bool animating;
    public float timeBetweenActive;
    float timeSinceActive;
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


        anim.SetBool("active", active);
        anim.SetBool("continue", inLoop);


            if (!active)
                timeSinceActive += Time.deltaTime;
            else
                timeSinceActive = 0.0f;


		
	}

    //if(stateAltered)
    //{
    //    anim.SetBool("Active", Active);
    //    anim.SetBool("inLoop", inLoop);
    //    stateAltered = false;
    //}

    //if (inLoop)
    //    timeSinceAnimStart += Time.deltaTime;
    //else
    //    timeSinceAnimStart = 0.0f;
}
