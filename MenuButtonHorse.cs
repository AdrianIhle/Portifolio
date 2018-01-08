using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// button actions specified object
public class MenuButtonHorse : MonoBehaviour {

    public Button MountButton;
    public Button UnmountButton;
    public Button attack;
    public Button useCrown;
    public Button showSkull;
    public GameObject Player;
    public GameObject Parent;
    public HorseRiding horseRiding;

    public float InteractionRange;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Parent = transform.parent.gameObject;
        InteractionRange = 10;
        horseRiding = GameObject.FindGameObjectWithTag("Horse").GetComponent<HorseRiding>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (horseRiding.isRiding)
            UnmountButton.interactable = true;
        else
            UnmountButton.interactable = false;

	}

    void FixedUpdate()
    {
        if (Mathf.Abs(Player.transform.position.x - Parent.transform.position.x) < InteractionRange && Mathf.Abs(Player.transform.position.z - Parent.transform.position.z) < InteractionRange)
        {
            MountButton.interactable = true;
            useCrown.interactable = true;
            attack.interactable = true;
            showSkull.interactable = true;
        }

        else
        {
            MountButton.interactable = false;
            useCrown.interactable = false;
            attack.interactable = false;
            showSkull.interactable = false;
        }

    }
}
