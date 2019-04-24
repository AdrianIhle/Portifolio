using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour {


    public float delay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(DestroyObject());
	}
    
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }

}
