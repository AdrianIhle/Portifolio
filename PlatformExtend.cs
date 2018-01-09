using UnityEngine;
using System.Collections;

public class PlatformExtend : MonoBehaviour {

    public float startPosX = 207f;
    public float endPosX;
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
        }

    }
}
