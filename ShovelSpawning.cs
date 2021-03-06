﻿using UnityEngine;
using System.Collections;
//spawns and ensures only one instance of object over all scenes
public class ShovelSpawning : MonoBehaviour {

	public GameObject Object;
	GameObject ExistingObject;

    public BoolsForReset resetBool;
    bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        resetBool = GameObject.FindGameObjectWithTag("Player").GetComponent<BoolsForReset>();
        ExistingObject = GameObject.FindGameObjectWithTag ("Shovel");

        if (resetBool.shovel)
            gameObject.SetActive(false);
        else if (ExistingObject == null)
        {
			Instantiate (Object, this.transform.position, Quaternion.identity);
		}
	}
}
