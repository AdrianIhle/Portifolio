using UnityEngine;
using System.Collections;
//allows for paleyr to interact, and freezes player to avoid bugs and unintutive gameplay
public class OnMouseClickInteraction : MonoBehaviour {
	public Canvas InteractionMenu;
	Vector3 itemPosition;
	RaycastHit hit;
	Vector3 hitPosition;
	GameObject Player;
	Rigidbody PlayerRigidbody;

	// Use this for initialization
	void Start () {
		InteractionMenu = GetComponentInChildren<Canvas> ();
		InteractionMenu.enabled = false;
		Player = GameObject.Find ("Player");
		PlayerRigidbody = Player.GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		InteractionMenu = GetComponentInChildren<Canvas> ();
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		itemPosition = this.transform.position;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Interactable") {
				if (Input.GetMouseButtonDown (1)) {
					InteractionMenu.enabled = true;
					PlayerRigidbody.isKinematic = true;
				}
				if (Input.GetMouseButtonUp (1)) {
					InteractionMenu.enabled = false;
					PlayerRigidbody.isKinematic = false;
				}
			}
		}
		
	
	}
}
