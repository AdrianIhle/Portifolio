using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledTextureAnimation : MonoBehaviour {

    public bool isAnimating;
    public int rows = 1;
    public int columns = 1;
    public int fps = 24;
    int index;
    int lastIndex;

    private Vector2 vec;
    private Renderer currentRenderer;


	// Use this for initialization
	void Start () {

        vec = new Vector2(1.0f / rows, 1.0f / columns);
        currentRenderer = GetComponent<Renderer>();
        if(currentRenderer == null)
            enabled = false;

		
	}
	
	// Update is called once per frame
	void Update () {
        if (isAnimating)
        {
            index = (int)(Time.timeSinceLevelLoad * fps) % (rows * columns);
            if (index != lastIndex)
            {
                int uCord = index % rows;
                int vCord = index % columns;

                Vector2 offset = new Vector2(uCord * vec.x, 1.0f - vec.y - columns * vec.y);
                currentRenderer.material.SetTextureOffset("_MainTex", offset);
                currentRenderer.material.SetTextureScale("_MainTex", vec);

                lastIndex = index;
            }
        }
	}
}
