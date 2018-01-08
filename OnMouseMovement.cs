using UnityEngine;
using System.Collections;
// movement based on clicking on navmesh position
public class OnMouseMovement : MonoBehaviour {
	
	Vector3 targetPosition;
	RaycastHit hit;
	GameObject SpawnLocation;
	public GameObject Player;

	//used for raycasting movement
	//	public float speed = 1;


	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	
	// Update is called once per frame
	void Update () {
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();


		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);					//acquires the mouse position in world space by casting a ray from the screen to clicked position
		targetPosition = transform.position;
		targetPosition = hit.point;												//In combination with Physics.Raycast (ray, out hit), defines the targetPosition as where the mouse hit, stores the position.

		if (Input.GetMouseButton(1)) {

			//Navmesh movement
			if(Physics.Raycast (ray, out hit)){
				agent.destination = targetPosition;
			}s
		}
	}
}
