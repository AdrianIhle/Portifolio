using UnityEngine;
using System.Collections;
// action of player interacting with themself
public class PlayerInteraction : MonoBehaviour
{
    // Use this for initialization
    public GameObject king;
    public GameObject[] guards;
    PopUp JulietEmoji;
    GameObject popUpObject;
	public GameObject prompter;

    void Start ()
	{
        king = GameObject.FindGameObjectWithTag("Juliet");
        popUpObject = GameObject.Find("JulietPopUp");
        JulietEmoji = king.GetComponent<PopUp>();
		prompter = GameObject.Find("Prompter");                 //Finds the Prompter
        guards = GameObject.FindGameObjectsWithTag("Guard");
    }

    public void crownSelf()
    {
        GetComponent<BoolsForReset>().crownSelf = true;
		JulietEmoji.setEmojiPopup(JulietEmoji.heart, true);
        GuardPopUp(KingEmoji.angry, true);

    }

    void GuardPopUp(Material Emoji, bool poppingUp)
    {
        for (int i = 0; i < guards.Length; i++)
        {
            guards[i].GetComponentInChildren<PopUp>().setEmojiPopup(Emoji, poppingUp);
        }
    }
}