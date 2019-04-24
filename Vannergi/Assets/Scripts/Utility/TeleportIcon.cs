using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportIcon : MonoBehaviour {

    public Sprite[] sprites;
    public Image currentImage;
    public int max;
    public int currentFrame;
	// Use this for initialization
	void Start () {
        currentImage = GetComponent<Image>();
        max = sprites.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentFrame == max)
        {
            Animate();
        }
		
	}

    void Animate()
    {
        for (int i = 0; i < max; i++)
        {
            currentImage.sprite = sprites[i];
            currentFrame = i;
        }
    }
}
