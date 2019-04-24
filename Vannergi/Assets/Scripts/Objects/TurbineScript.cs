using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineScript : ObjectScript {

    public ThirdStageManager thirdManager;
    // Use this for initialization
    void Start()
    {
        rotating = false;
        thirdManager = FindObjectOfType<ThirdStageManager>();
        objectBoss = (LocalManager)thirdManager;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFixed)
        {
            thirdManager.turbineOffline = false;
        }

    }
}
