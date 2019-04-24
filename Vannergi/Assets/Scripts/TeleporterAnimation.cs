using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterAnimation : MonoBehaviour {

    public float texRotationSpeed;
    public float objRotationSpeed;
    [Range(0.0f, 1.0f)]
    public float alphaCutOut;
    public float reductionValue;
    public Transform[] objects;

    private float texSpeed;
    private float objSpeed;
    private float cutOut;

    public float variation;
    public float varMax;
    public float varMin;

    public bool increase;
    public bool decrease;
    public bool triggerChange;

    public float timer;
    public float timerThreshold;
    int increments;
    public float speed;
	// Use this for initialization
	void Start () {
        objects = GetChildren();
        increments = (int)timerThreshold * 40;
	}

    private void Update()
    {
        if (decrease)
            alphaCutOut = Mathf.LerpUnclamped(alphaCutOut, varMax, speed /timerThreshold);
        else if (increase   )
            alphaCutOut = Mathf.LerpUnclamped(alphaCutOut, varMin, speed /timerThreshold);


    }

    // Update is called once per frame
    void FixedUpdate () {

        if(increase || decrease)
        {
            timer += Time.deltaTime;
        }

        //if(alphaCutOut < varMin || alphaCutOut > varMax)
        //{
        //    increase = !increase;
        //    decrease = !decrease;
        //    timer = 0.0f;

        //}


        if(timer > timerThreshold)
        {
            increase = !increase;
            decrease = !decrease;
            timer = 0.0f;
        }



        for (int i = 0; i < objects.Length; i++)
        {
            float rates = 1 - i * reductionValue;
            objects[i].GetComponent<Renderer>().material.SetFloat("_RotSpeed", texRotationSpeed );
            objects[i].GetComponent<Renderer>().material.SetFloat("_Cutoff", alphaCutOut );
            objects[i].GetComponent<Rotation>().speed = objRotationSpeed ;
        }
	}

    Transform[] GetChildren()
    {
        Transform[] t = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            t[i] = transform.GetChild(i);
        }

        return t;
    }

    void AnimateValues()
    {
        texSpeed = texRotationSpeed;
        objSpeed = objRotationSpeed  ;
        cutOut = alphaCutOut  ;
    }

    IEnumerator Increase(float delay)
    {
        while(variation < varMax)
        {
            variation += 0.1f;
        }

       yield return new WaitForSeconds(delay);
    }

    IEnumerator Decrease(float delay)
    {
        while (variation > varMax)
        {
            variation -= 0.1f;
        }

        yield return new WaitForSeconds(delay);
    }

}
