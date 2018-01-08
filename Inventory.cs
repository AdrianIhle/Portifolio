using UnityEngine;
using System.Collections;
// handles inventory of the player, and  the bools triggering what options the player has as. Items held could easily be changed for enums 
public class Inventory : MonoBehaviour {

	GameObject inventory;
	public Transform child;
	public int itemInHand;
    public float itemHeight;

    public bool crownInHand;
	public bool luteInHand;
	public bool shovelInHand;
	public bool swordInHand;
	public bool skullInHand;

    public BoolsForReset resetBool;

	void Awake(){
		DontDestroyOnLoad (child);
	}

	void Start () {
        child = null;
		inventory = gameObject;
		itemInHand = 0;
		crownInHand = false;
		luteInHand = false;
		shovelInHand = false;
		swordInHand = false;
		skullInHand = false;

        resetBool = GameObject.FindGameObjectWithTag("Player").GetComponent<BoolsForReset>();
	
	}
	
	// Update is called once per frame
	void Update () {
		itemHeld ();

		switch (itemInHand) {
        case 0:
            crownInHand = false;
            swordInHand = false;
            luteInHand = false;
            shovelInHand = false;
            skullInHand = false;
            break;
        case 1:
			crownInHand = true;
                swordInHand = false;
                luteInHand = false;
                shovelInHand = false;
                skullInHand = false;
                resetBool.crown = true;
                itemHeight = 0.5f;
                break;
		case 2:
                crownInHand = false;
			swordInHand = true;
                luteInHand = false;
                shovelInHand = false;
                skullInHand = false;
                resetBool.sword = true;
                itemHeight = 3f;
                break;
		case 3:
                crownInHand = false;
                swordInHand = false;
                luteInHand = true;
                shovelInHand = false;
                skullInHand = false;
                itemHeight = 2f;
                resetBool.lute = true;
			break;
		case 4:
                crownInHand = false;
                swordInHand = false;
                luteInHand = false;
                shovelInHand = true;
                skullInHand = false;
                itemHeight = 2.5f;
                resetBool.shovel = true;
			break;
		case 5:
                crownInHand = false;
                swordInHand = false;
                luteInHand = false;
                shovelInHand = false;
                skullInHand = true;
                itemHeight = 0.5f;
                resetBool.skull = true;
			break;
		default:
			break;

		}
	
	}
    void itemHeld()
    {
        if (child != null)
        {
            if (child.name == "Crown")
            {
                itemInHand = 1;
            }
            if (child.name == "Sword")
            {
                itemInHand = 2;
            }
            if (child.name == "Lute")
            {
                itemInHand = 3;
            }
            if (child.name == "Shovel")
            {
                itemInHand = 4;
            }
            if (child.name == "Skull")
            {
                itemInHand = 5;
            }
        }
    }
}
