using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScript : ObjectScript {


    public ThirdStageManager thirdManager;
    // Use this for initialization
    void Start()
    {
        thirdManager = FindObjectOfType<ThirdStageManager>();
        this.GetComponent<Collider>().enabled = false;
        objectBoss = (LocalManager)thirdManager;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFixed)
        {
            thirdManager.tubeNotInPlace = false;
            this.GetComponent<Collider>().enabled = false;
        }
        else if (!thirdManager.turbineOffline && !thirdManager.shaftNotInPlace)
            GetComponent<Collider>().enabled = true;

    }

}
