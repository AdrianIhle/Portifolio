using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimastionPointScript : MonoBehaviour {
    public Transform next;
    public bool isLast;
    public bool isFirst;

	// Use this for initialization
	void Start () {
        //aqcuires the next point in the movement path. 
        if (transform.GetSiblingIndex() + 1 < transform.parent.childCount)
        {
            next = transform.parent.GetChild(transform.GetSiblingIndex() + 1);
        }
        if (next == null)
            isLast = true;

        if (transform.GetSiblingIndex() == 0)
            isFirst = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        print("anim test col " + other.name);
        //aquires current position and the next position to use for lerped movement
        if (other.transform.CompareTag("Olive"))
        {
            if (isFirst)
                GameObject.FindObjectOfType<SecondStageManager>().moveToDam = false;
            other.GetComponent<Olive>().moving = true;
            if (next != null)
            {
                other.GetComponent<Olive>().target = next;
            }


            if (isLast)
            {
                other.GetComponent<Olive>().onTheMove = false;
                other.GetComponent<Olive>().moving = false;
                if (this.transform.parent.name == "Path 2")
                    other.GetComponent<Olive>().OlivePointTowards(FindObjectOfType<ThirdStageManager>().Shaft, 0);
                if (this.transform.parent.name == "Path 3")
                    other.GetComponent<Olive>().OlivePointTowards(FindObjectOfType<ThirdStageManager>().Pipe, 0);
                FindObjectOfType<ThirdStageManager>().shouldMove = false;
            }

        }
    }
}
