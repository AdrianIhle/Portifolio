using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringUI : MonoBehaviour {

    public Transform target;
    public Camera m_Camera;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        m_Camera = Camera.main;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(target.position);
        Vector3 wantedRor = 
        transform.position = target.position +offset;
        transform.LookAt(transform.position, m_Camera.transform.rotation * Vector3.up);
    }
}
