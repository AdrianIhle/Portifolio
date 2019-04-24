using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftScript : ObjectScript {

    ThirdStageManager thirdManager;
    // Use this for initialization
    void Start()
    {
        thirdManager = FindObjectOfType<ThirdStageManager>();
        objectBoss = (LocalManager)thirdManager;
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (isFixed)
        {
            thirdManager.shaftNotInPlace = false;
            ToggleRotation(true);
        }
        if (rotating)
        {
            this.transform.Rotate(new Vector3(0.0f, 4.0f, 0.0f));
        }
    }


}
