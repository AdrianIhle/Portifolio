using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public bool eventHappened;
    public Olive olive;

	// Use this for initialization
	 protected void Start () {
        olive = GameObject.FindGameObjectWithTag("Olive").GetComponent<Olive>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public virtual IEnumerator DelayedEventCall(float delay)
    {
        print("starting delayed event call");
        yield return new WaitForSeconds(delay);
        eventHappened = true;
    }
}
