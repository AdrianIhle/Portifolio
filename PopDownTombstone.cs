using UnityEngine;
using System.Collections;
//triggers event to specific player action

public class PopDownTombstone : MonoBehaviour {

	private bool rotating;
	// Use this for initialization


	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown("space"))
		{
			tombFall();
		}
	}
	public void tombFall()
	{
		StartCoroutine("tombDown");
	}

	public IEnumerator tombDown()
	{
		if (!rotating)
		{
			rotating = true;
			for (int i = 0; i <= 30; i++)
			{
				transform.Rotate(transform.rotation.x - 3, transform.rotation.y, transform.rotation.z);
				yield return new WaitForEndOfFrame();
			}

		}
		else
		{
			yield break;
		}
	}

}
