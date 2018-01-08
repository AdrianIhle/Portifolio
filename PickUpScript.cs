using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
// allows player to pick up, bind to hand position, and add to inventory and enacts appropriate changes to interactablity
public class PickUpScript : MonoBehaviour {

	public Button PickupButton;
    public Button DropButton;
	public GameObject Player;
    public GameObject Parent;

    public int currentScene;
    public GameObject bindTo;
    BoxCollider boxColl;
    Inventory inventory;

    public float pickUpRange;
    public float moveDownSpeed = 1f;

    public bool holding;
    public bool dropable;
    public bool droppingDown;

    void OnEnable()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Parent = transform.parent.gameObject;
        bindTo = GameObject.Find("BindToCollider");
        boxColl = GetComponent<BoxCollider>();
        inventory = bindTo.GetComponent<Inventory>();
        pickUpRange = 10;
        Player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log("Starting pickup script");
    }

	void FixedUpdate()
    {
		if (Mathf.Abs (Player.transform.position.x - Parent.transform.position.x) < pickUpRange && Mathf.Abs (Player.transform.position.z - Parent.transform.position.z) < pickUpRange)
		{
			PickupButton.interactable = true;
		}

		else
		{
			PickupButton.interactable = false;
		}

    }

	void Update()
    {


        if (holding)
        {
            Parent.transform.position = bindTo.transform.position;
            boxColl.enabled = false;
            dropable = true;
            DropButton.interactable = true;
        }
        else if (!holding)
        {
            StartCoroutine(boxCollEnabled());
            dropable = false;
            DropButton.interactable = false;
        }

    }

    public void PickUp()
    {
        if (inventory.child != null && inventory.child.tag != this.tag)
        {
            inventory.child.GetComponent<PickUpScript>().Drop();
        }
        holding = true;
        inventory.child = transform;
        Player.GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();
    }



	public void Drop()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        holding = false;
        inventory.child = null;
        dropAtDistance();
    }

    IEnumerator boxCollEnabled()
    {
        yield return new WaitForSeconds(0.01f);
        boxColl.enabled = true;

    }

    
    void dropAtDistance()
    {
        bool dropping;
        if (dropable)
        {
            dropping = true;
            if (dropping)
            {
                if (Player.transform.position.z > this.transform.position.z)
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (1 / inventory.itemHeight), this.transform.position.z - 1);
                if (Player.transform.position.z < this.transform.position.z)
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (1 / inventory.itemHeight), this.transform.position.z + 1);
                if (Player.transform.position.x > this.transform.position.x)
                    this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y - (1 / inventory.itemHeight), this.transform.position.z);
                if (Player.transform.position.x < this.transform.position.x)
                    this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y - (1 / inventory.itemHeight), this.transform.position.z);

                dropping = false;

            }
            Player.GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();
        }
    }
}
