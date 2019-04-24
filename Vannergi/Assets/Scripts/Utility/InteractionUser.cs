using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionUser : MonoBehaviour {
	
	public Canvas UI;
    public ProgressBar progressBar;
	float orgHitDistance = 0;
    public float teleportDistance = 10.0f;
	float timer = 0;
	float timeThreshold = 1;

	bool isRoaring = false;


    public Vector3 interactionVector;
    Ray interactionRay;
    RaycastHit interactionHit;

    Vector3 teleporterVector;
    Ray teleportRay;
    RaycastHit teleportHit;

    public bool objectInteracted;
    public bool teleportInteracted;
    public bool isInteracting;

    public Vector3 hitPos;
    // Use this for initialization
    void Start () {
        UI.enabled = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
        ObjectInteraction(150.0f);
        TeleportInteraction(teleportDistance);
        ManageUI();
		}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionHit.point, 2.0f);
    }


    void ObjectInteraction(float interactionRange)
	{
		interactionVector = transform.TransformDirection (Vector3.forward);
        interactionRay = new Ray (transform.position, interactionVector);
		Debug.DrawRay (transform.position, interactionVector * interactionRange, Color.green);
		if (Physics.SphereCast(interactionRay, 2.0f,out interactionHit, interactionRange)) 
		{
            if (interactionHit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable") && interactionHit.transform.tag != "Teleporter") {
                hitPos = interactionHit.point;
                objectInteracted = true;
				if (timer > timeThreshold) {
                    interactionHit.transform.gameObject.SendMessage ("ToggleActivated");
                    interactionHit.transform.gameObject.SendMessage ("RayHitToPos", interactionRay.GetPoint (orgHitDistance));
					if (isRoaring)
                        interactionHit.transform.gameObject.SendMessage ("SetRoar", true);
					else
                        interactionHit.transform.gameObject.SendMessage ("SetRoar", false);
				}
                
			}
			else {

			}

		} else if(!Physics.Raycast (interactionRay, out interactionHit, interactionRange)) {
		}
	}

    void TeleportInteraction(float interDistance)
    {
        teleporterVector = transform.TransformDirection(Vector3.forward);
        teleportRay = new Ray(transform.position, teleporterVector);
        Debug.DrawRay(transform.position, teleporterVector * interDistance, Color.red);

        if (Physics.SphereCast(teleportRay, 2.0f, out teleportHit, interDistance))
        {

            if (teleportHit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable") && teleportHit.collider.tag == "Teleporter")
            {
                teleportInteracted = true;
                if (timer > timeThreshold)
                {
                    teleportHit.transform.gameObject.GetComponent<InteractionResponse>().ToggleActivated();
                }
            }
        }
        else if (!Physics.Raycast(teleportRay, out teleportHit, interDistance))
        {

        }
    }
	
	public void SetOrgDist(float dist)
	{
		orgHitDistance = dist;
	}

	public void Roaring(bool state)
	{
		isRoaring = state;
	}

    void ManageUI()
    {
        float fillRatio = timer / timeThreshold;
        progressBar.fill = fillRatio;
        if (objectInteracted || teleportInteracted)
        {
            if (!isInteracting)
            {
                UI.enabled = true;
                timer += Time.deltaTime;
                objectInteracted = false;
                teleportInteracted = false;
            }
        }
        else {
            timer = 0.0f;
            UI.enabled = false;
        }
    }

    public void ToggleInteracting(bool state)
    {
        isInteracting = state;
        UI.enabled = false;
    }
}
