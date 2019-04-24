using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

    public bool rotating;
    public bool reversing;
    public float speed;
    public enum rotAx
    {
        X,
        Y,
        Z,
    }

    public rotAx rotationAxis;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reversing)
            ReverseSpeed();

        if (rotating)
        {
            switch (rotationAxis)
            {
                case rotAx.X:
                    this.transform.Rotate(new Vector3(speed, 0.0f, 0.0f));
                    break;
                case rotAx.Y:
                    this.transform.Rotate(new Vector3(0.0f, speed, 0.0f));
                    break;
                case rotAx.Z:
                    this.transform.Rotate(new Vector3(0.0f, 0.0f, speed));
                    break;
                default:
                    break;
            }

        }
    }

    public void ToggleRotation(bool state)
    {
        rotating = state;
    }

    void ReverseSpeed()
    {
        speed *= -1;
        reversing = false;
    }
}
