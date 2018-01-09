using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBamboo : MonoBehaviour {

	public GameObject[] objs;
	Transform[] Transforms;
	public List<Transform> SpawnPoints;

	// Use this for initialization
	void Start () {

		Transforms = new Transform[this.transform.childCount];
		Transforms = GetComponentsInChildren<Transform> ();

		for(int i= 1; i <= Transforms.GetLength(0)-1; i++)
		{
			if (Transforms [i].name == "BambooSpawnPoint") {
				print ("adding spawn");
				Transform tempObj = Transforms [i];
				SpawnPoints.Add(tempObj);
			}
		}
			
		SpawnSequence ();
	}


	// Update is called once per frame
	void Update () {
		
	}




	void Spawn(int spawnpoint)
	{

		Instantiate (objs [Random.Range (0, objs.Length-1)], SpawnPoints [spawnpoint].transform.position, Quaternion.identity, null);
	}

	void SpawnSequence()
	{
		print ("Spawnpoints: " + SpawnPoints.Count);
		for (int i = 0; i < SpawnPoints.Count; ++i) {
			Spawn (i);
		}
	}
}
