using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//handles interactions for specified object
public class KingInteraction : MonoBehaviour
{

	public GameObject SceneController;
	GameObject popUpObject;
	PopUp KingEmoji;
	GameObject[] Guards;
	public GameObject Player;


	// each of these ensures that the action of the player is registered and buttons react as well
	public void showSkull(){
		Player.GetComponent<BoolsForReset> ().showSkull = true;
		KingEmoji.setEmojiPopup (KingEmoji.impatience, true);
	}

	public void playForTheCourt(){
		Player.GetComponent<BoolsForReset> ().playedLute = true;
		KingEmoji.setEmojiPopup (KingEmoji.impatience, true);
		GuardPopUp (KingEmoji.happy, true);
	}

	public void crownKing(){
		Player.GetComponent<BoolsForReset> ().crownOnKing = true;
		KingEmoji.setEmojiPopup (KingEmoji.happy, true);
		GuardPopUp (KingEmoji.happy, true);
	}

	public void attackKing(){
		Player.GetComponent<BoolsForReset> ().attackKing = true;
		KingEmoji.setEmojiPopup (KingEmoji.dead, true);
		GuardPopUp (KingEmoji.angry, true);
	}

	void OnEnable()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

    // Use this for initialization
    void Start()
    {
		// finds the scenecontroller of the level
		SceneController = GameObject.Find ("SceneController");
		popUpObject = GameObject.Find ("KingPopUp");
		KingEmoji= popUpObject.GetComponent<PopUp>();
		Guards = GameObject.FindGameObjectsWithTag ("Guard");
    }
		
	void GuardPopUp(Material Emoji, bool poppingUp )
	{
		for (int i = 0; i < Guards.Length; i++) {
			Guards[i].GetComponentInChildren<PopUp>().setEmojiPopup(Emoji, poppingUp);
		}
	}
}
