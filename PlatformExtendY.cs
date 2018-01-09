using UnityEngine;
using System.Collections;

public class PlatformExtendY : MonoBehaviour {


    public float startPosX = 207f;
    public float startPosY;
    public float endPosX;
    public float endPosY;
    public bool targetHit = false;
    public GameObject Target;

    void Update()
    {

        if (Target.GetComponent<TargetHit>().TargetIsHit)
        {
            if (startPosX < endPosX)
            {
                startPosX += 0.1f;
                this.transform.position = this.transform.position + (new Vector3(+0.1f, 0, 0));

            }
            if (startPosY < endPosY)
            {
                startPosY += 0.1f;
                this.transform.position = this.transform.position + (new Vector3(0, +0.1f, 0));

            }
        }

    }
}
