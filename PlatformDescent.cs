using UnityEngine;
using System.Collections;

public class PlatformDescent : MonoBehaviour {

    public float startPosY = -4.00f;
    public float endPosY;
    public bool targetHit = false;
    public GameObject Target;

	void Update () {

        if (Target.GetComponent<TargetHit>().TargetIsHit)
        {
            if (startPosY > endPosY)
            {
                startPosY -= 0.1f;
                this.transform.position = this.transform.position + (new Vector3(0, -0.1f, 0));

            }
        }

    }
}
