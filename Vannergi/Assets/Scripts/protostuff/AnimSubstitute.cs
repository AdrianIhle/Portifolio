using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSubstitute : MonoBehaviour
{

    public float moveIncs = 5.0f;
    public bool startMoving;
    public GameObject animationPath;
    bool moving;
    public float moveTime;
    Vector3[] pos = new Vector3[2];
    // Use this for initialization
    void Start()
    {
        startMoving = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            print(animationPath.transform.GetChild(0).name);
            transform.position = Vector3.Lerp(transform.position, animationPath.transform.GetChild(0).position, moveIncs);
            startMoving = false;
        }
    }

    private void FixedUpdate()
    {

        float timestarted = Time.time;
        float timeSinceStarted = 0.0f;

        float percentageComplete = 0.0f;
        if (moving)
        {
            timeSinceStarted += Time.deltaTime;
            percentageComplete = timeSinceStarted / moveTime;
            transform.position = Vector3.Lerp(pos[0], pos[1], moveIncs);
            if (percentageComplete >= 1.0f)
                moving = false;
        }
    }

    public void MoveActor(Vector3[] newPos)
    {
        pos = newPos;
        moving = true; 
    }



    public void ToggleStartMove(bool state)
    {
        startMoving = state;
    }
}
