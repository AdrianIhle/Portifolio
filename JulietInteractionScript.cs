using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//handles interactions for specified object
public class JulietInteractionScript : MonoBehaviour {

	public GameObject Player;
	public GameObject SceneController;
	public GameObject popUpObject;
	public PopUp JulietEmoji;

	public void serenade(){
		Player.GetComponent<BoolsForReset> ().playedSerenade = true;
		SceneController.GetComponent<scene2Script> ().serenadeButton.GetComponent<Image> ().color = Color.green;
		SceneController.GetComponent<scene2Script> ().serenadeButton.enabled = false;
		JulietEmoji.setEmojiPopup (JulietEmoji.heart, true);
	}

	public void guitarSolo(){
		Player.GetComponent<BoolsForReset> ().playedMetal2 = true;
		SceneController.GetComponent<scene2Script> ().guitarSoloButton.GetComponent<Image> ().color = Color.green;
		SceneController.GetComponent<scene2Script> ().guitarSoloButton.enabled = false;
		JulietEmoji.setEmojiPopup (JulietEmoji.happy, true);
	}

	public void showSkull(){
		Player.GetComponent<BoolsForReset> ().showedSkull2 = true;
		SceneController.GetComponent<scene2Script> ().showSkullButton.GetComponent<Image> ().color = Color.red;
		SceneController.GetComponent<scene2Script> ().fenceWithButton.enabled = false;
		JulietEmoji.setEmojiPopup (JulietEmoji.exmark, true);
	}

	public void fenceWith(){
		Player.GetComponent<BoolsForReset> ().fenceAtJuliet = true;
		SceneController.GetComponent<scene2Script> ().fenceWithButton.GetComponent<Image> ().color = Color.red;
		SceneController.GetComponent<scene2Script> ().fenceWithButton.enabled = false;
		JulietEmoji.setEmojiPopup (JulietEmoji.angry, true);
	}


	void OnEnable()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Use this for initialization
	void Start () {
		SceneController = GameObject.Find ("SceneController");
		popUpObject = GameObject.Find ("JulietPopUp");
		JulietEmoji = popUpObject.GetComponent<PopUp>();					
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
