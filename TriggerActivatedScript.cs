using UnityEngine;
using System.Collections;

public class TriggerActivatedScript : MonoBehaviour {

    public GameObject Trigger;                                                          //used as a refereance to the trigger
    public bool TargetHit;                                                              //used to indicate whether the trigger is triggered or not

    void Update()
    {
        TargetHit = Trigger.GetComponent<TargetHit>().TargetIsHit;                  //Reads of the bool in the Game object that is used as a trigger 
        if (TargetHit)
        {                                                               //if the trigger is triggered the object will be activated
            this.GetComponent<PlatformMovementY>().enabled = true;

        }

    }

}
