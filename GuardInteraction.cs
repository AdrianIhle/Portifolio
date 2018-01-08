using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//handles interactions for specified object
public class GuardInteraction : MonoBehaviour {

	public GameObject SceneController;
	PopUp KingEmoji;
	GameObject[] Guards;
	public GameObject Player;

	public void AttackGuard()
	{
		Player.GetComponent<BoolsForReset> ().attackGuard = true;
		KingEmoji.setEmojiPopup (KingEmoji.exmark, true);
		GuardReaction (KingEmoji.dead, KingEmoji.exmark, true);

		
	}

	public void CrownGuard()
	{
		Player.GetComponent<BoolsForReset> ().crownOnGuard = true;
		KingEmoji.setEmojiPopup (KingEmoji.angry, true);
		GuardReaction (KingEmoji.happy, KingEmoji.exmark, true);
		
	}

	// Use this for initialization
	void Start()
	{
		// finds the scenecontroller of the level
		SceneController = GameObject.Find ("SceneController");
		KingEmoji= GameObject.FindGameObjectWithTag("King").GetComponentInChildren<PopUp>();
		Guards = GameObject.FindGameObjectsWithTag ("Guard");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void GuardReaction(Material thisEmoji, Material otherEmoji, bool poppingUp)
	{
		foreach(GameObject guard in Guards)
		{	
			if(guard == this)
				guard.GetComponentInChildren<PopUp>().setEmojiPopup(thisEmoji, poppingUp);
			else
				guard.GetComponentInChildren<PopUp>().setEmojiPopup(otherEmoji, poppingUp);
		}
	}
}
