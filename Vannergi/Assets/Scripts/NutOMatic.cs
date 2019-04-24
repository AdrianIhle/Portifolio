using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutOMatic : MonoBehaviour {

    Animator anim;
    public bool active;
    public bool spawning;
    public bool permaActive;
    public GameObject house;
    public float force;
    float timer;
    public Transform spawnPoint;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        anim.SetBool("active", active);
        if (spawning)
        {
            GameObject g =
            Instantiate(house ,spawnPoint, true);
            g.transform.position = spawnPoint.position;
            spawnPoint.DetachChildren();
            g.AddComponent<Rigidbody>();
            Rigidbody rb = g.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, force, 0));
            spawning = false;
            timer = 0.0f;
        }

        if(permaActive)
        {
            timer += Time.deltaTime;
            if (timer > 7.0f)
                spawning = true;
        }

        if (active)
            GetComponentInChildren<Rotation>().rotate = true;
        else
            GetComponentInChildren<Rotation>().rotate = false;
	}
}
