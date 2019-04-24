using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeysirScript : MonoBehaviour {

    ParticleSystem PS;

	// Use this for initialization
	void Start () {
        PS = GetComponent<ParticleSystem>();
        PS.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Olive")
            PS.Play();
    }

}

