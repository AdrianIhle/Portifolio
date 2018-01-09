using UnityEngine;
using System.Collections;

public class TriggeredBoundary : MonoBehaviour {

    public GameObject RotatingObject1;
    public GameObject RotatingObject2;

    public bool turn = false;

    public float NewSpeed = 1f;

    void Update()
    {
        if (turn == true)
        {
            RotatingObject1.transform.eulerAngles = new Vector3(0, 180, 0);
            RotatingObject2.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (turn == false)
        {
            RotatingObject1.transform.eulerAngles = new Vector3(0, 0, 0);
            RotatingObject2.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D boundary){											//if an enemy with the EnemyBoundryMovement script encounters this game object's collider, then the trigger inverses their movement
		if (boundary.tag == "enemy boundary") {
            turn = !turn;
        } 
	}
}
