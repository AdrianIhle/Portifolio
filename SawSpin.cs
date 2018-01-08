using UnityEngine;
using System.Collections;
// spinning saw animation
public class SawSpin : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Rotate (new Vector3 (0, speed, 0));
	
	}
}
