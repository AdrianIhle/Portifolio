using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour {
	[SerializeField]
	Image displayedImage;

	public Sprite[] sprites;
	int max;
	int current;
    float increment;
    public float fill;
	// Use this for initialization
	void Start () {
		max = sprites.Length - 1;
		current = 0;
		displayedImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
        float aproxFrame = fill * max;
        current = (int)aproxFrame;
		if (fill != 0.0f) {
            if (current > max)
                current = max;
			displayedImage.sprite = sprites [current];
		}
		
	}
}
