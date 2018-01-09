using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmeControl : MonoBehaviour{
	public float tScale = 1f;

	void OnGUI()
	{
		Time.timeScale = tScale;
	}
}


