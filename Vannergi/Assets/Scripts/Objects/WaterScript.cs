using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    public bool waterFalling = false;
    public bool waterRising = false;
    public float speed;
    public float bottom;
    Vector3 botPos;
    Vector3 topPos;
    // Use this for initialization
    void Start()
    {
        topPos = transform.position;
        botPos = new Vector3(topPos.x, topPos.y -bottom, topPos.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waterFalling)
        {
            transform.position = Vector3.Lerp(transform.position, botPos, speed * Time.deltaTime);
        }
        else if (waterRising)
        {
            transform.position = Vector3.Lerp(transform.position, topPos, speed * Time.deltaTime);
        }

    }

    public IEnumerator WaterSink()
    {
        waterRising = false;
        waterFalling = true;
        while (Vector3.Magnitude(transform.position - botPos) > 0.1f)
            yield return null;
        waterFalling = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public IEnumerator WaterRise()
    {
        waterFalling = false;
        GetComponent<MeshRenderer>().enabled = true;
        waterRising = true;
        while (Vector3.Magnitude(transform.position - topPos) > 0.1f)
            yield return null;
        waterRising = false;

    }
}
