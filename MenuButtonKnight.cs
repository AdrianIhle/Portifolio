using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// button actions specified object
public class MenuButtonKnight : MonoBehaviour {

    public Button useShovel;
    public Button useLute;
    public Button attack;
    public HorseRiding horseRiding;

    // Use this for initialization
    void Start ()
    {
        horseRiding = GameObject.FindGameObjectWithTag("Horse").GetComponent<HorseRiding>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	if (horseRiding.isRiding)
       {
           attack.interactable = true;
           useLute.interactable = true;
           useShovel.interactable = true;
       }
   else
       {
           attack.interactable = false;
           useLute.interactable = false;
           useShovel.interactable = false;
       }
	}
}
