using UnityEngine;
using System.Collections;
// rotates staff of user to use for toggling saw switch
public class StaffRotation : MonoBehaviour {

	public bool Rotated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rotate()
	{
		if (!Rotated) {
			this.transform.Rotate (new Vector3 (0, 0, 90) ,Space.Self);
			
		} else {
			this.transform.Rotate (new Vector3 (0, 0, -90)*Time.deltaTime,Space.Self);
		}


	}
}
