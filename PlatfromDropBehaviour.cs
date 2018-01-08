using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// drops a platform and triggers an offmeshlink to allwo player to move across the fallen platform
public class PlatfromDropBehaviour : MonoBehaviour {

	public bool isShot;

	public Rigidbody platfrom;
	public UnityEngine.AI.OffMeshLink Link;
	public Button b;

	// Use this for initialization
	void Start () {
		isShot = false;
		Link.activated = false;
		b.interactable = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("update running ");
		if (isShot) {
			Debug.Log ("Is Shot is registered by if");
			Link.activated = true;
			platfrom.useGravity = true;
		}
	
	}


	public void shot()
	{
		isShot = true;
	}

	public void active()
	{
			b.interactable = true;
	}

	public void deactive()
	{
		b.interactable = false;
	}

}
