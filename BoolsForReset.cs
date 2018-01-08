using UnityEngine;
using System.Collections;
// resets all boools when spawned
public class BoolsForReset : MonoBehaviour
{
	public GameObject SceneController;

    public bool crown;
    public bool sword;
    public bool lute;
    public bool skull;
    public bool shovel;

	public bool crownSelf;
	public bool crownSelf2;

	public bool showSkull;
	public bool playedLute;
	public bool crownOnKing;
	public bool attackKing;
	public bool attackGuard;
	public bool crownOnGuard;
	public bool hideInBush;
	public bool digUpBush;

	public bool playedSerenade;
	public bool playedMetal2;
	public bool showedSkull2;
	public bool fenceAtJuliet;


	public bool swordHitSkull;
	public bool digUpTombstone;
	public bool digUpBush2;
	public bool talkToSkull;
	public bool digUpSkull;

	public bool mountHorse;
	public bool SwordOnKnight;
	public bool SwordOnHorse;
	public bool showSkullToHorse;
	public bool playLute4;
	public bool KnightHit;
	public bool crownHorse;
	public bool shovelOnKnight;

    void Start()
    {
		SceneController = GameObject.FindGameObjectWithTag ("SceneController");
		if(SceneController.GetComponent<DestroyPlayerIfSpawned>().playerSpawned)
			Destroy(gameObject);

		//Items
        crown = false;
        sword = false;
        lute = false;
        skull = false;
        shovel = false;

		crownSelf = false;
		crownSelf2 = false;
		//level 1
		showSkull = false;
		playedLute = false;
		crownOnKing = false;
		attackKing = false;
		attackGuard = false;
		crownOnGuard = false;

		//level 2
		playedSerenade = false;
		playedMetal2 = false;
		showedSkull2 = false;
		fenceAtJuliet = false;
		hideInBush = false;
		digUpBush = false;

		//level 3
		swordHitSkull = false;
		digUpTombstone = false;
		digUpBush2 = false;
		talkToSkull = false;
		digUpSkull = false;

		//level 4
		mountHorse = false;
		SwordOnKnight = false;
		SwordOnHorse = false;
		showSkullToHorse = false;
		playLute4 = false;
		KnightHit = false;
		crownHorse = false;
		shovelOnKnight = false;
}
}
