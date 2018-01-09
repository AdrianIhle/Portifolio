//bård ræstad
using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour {

	public float newSize;										//The given size in the camera zone
	public bool changeSize;										//Telling Unity to change to the new size
	public Camera World;									//This and the following three are the four cameraes we use in the game
	public Camera BlackPreview;
	public Camera WhitePreview;


	void FixedUpdate(){
		
		if (changeSize == true) {								//This tells Unity to change to this camera zone's newSize
				AdjustCamera ();
		}
	}

	void OnTriggerEnter2D (Collider2D player){					//This engages the camera change as soon as the player enter the camera zone

		if (player.tag == "Player") {
			changeSize = true;
		}
	}

	void OnTriggerExit2D (Collider2D player){					//This disengages the camera change as soon as the player exit the camera zone

		if (player.tag == "Player") {
			changeSize = false;
		}
	}

	void EnlargeCamera(){										//This enlarges every camera incrementally
		World.orthographicSize += 0.05f;
		BlackPreview.orthographicSize += 0.05f;
		WhitePreview.orthographicSize += 0.05f;
	}

	void ShrinkCamera(){										//This shrinks every camera incrementally
		World.orthographicSize -= 0.05f;
		BlackPreview.orthographicSize -= 0.05f;
		WhitePreview.orthographicSize -= 0.05f;
	}

	void AdjustCamera(){										//This decides if the cameraes are to be shrunken or enlarged

		if (World.orthographicSize > newSize) {
			ShrinkCamera ();
		}

		if (World.orthographicSize < newSize) {
			EnlargeCamera ();
		}
	}

}
