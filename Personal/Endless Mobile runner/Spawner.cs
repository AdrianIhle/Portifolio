using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] objs;
	public Vector3 displacementVector;


	// ################ NY ################
	public GameObject platformParent;
	public GameObject startField;
	// ################ NY ################




	// Use this for initialization
	void Start()
	{
		// ################ NY ################
		platformParent = GameObject.Find("PlatformParent");
		startField = GameObject.Find("StartField");
		// ################ NY ################
		Spawn();
	}



	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Platform") {
			SpawnTest ();
		}
		print (other.tag + "exited");
	}



	void Spawn()
	{

		// ################ NY ################
		// Har lagt til en parameter til slutt "parent". 
		// Forandret posisjonen fra "transform.position + displacementVector" til "forrige platform pluss displacementVector". 
		Vector3 lastPlatformPosition;
		if (platformParent.transform.childCount <= 0)
		{
			print ("test initialized");
			lastPlatformPosition = startField.transform.position;
		}
		else
		{
			print ("test continues");
			lastPlatformPosition = platformParent.transform.GetChild(platformParent.transform.childCount - 1).transform.position;
		}
		Instantiate(objs[Random.Range(0, objs.GetLength(0))], lastPlatformPosition + displacementVector, Quaternion.identity, platformParent.transform);
		// ################ NY ################
	}


	void SpawnTest()
	{
		int selection = 0;
		int StraightvCurve = Random.Range(0,9);

		if(StraightvCurve <= 5)
			selection = Random.Range(0,2);
		else if (StraightvCurve > 5)
			selection = Random.Range(3, objs.GetLength(0));



		// ################ NY ################
		// Har lagt til en parameter til slutt "parent". 
		// Forandret posisjonen fra "transform.position + displacementVector" til "forrige platform pluss displacementVector". 
		Vector3 lastPlatformPosition;
		if (platformParent.transform.childCount <= 0)
		{
			print ("test initialized");
			lastPlatformPosition = startField.transform.position;
		}
		else
		{
			print ("test continues");
			lastPlatformPosition = platformParent.transform.GetChild(platformParent.transform.childCount - 1).transform.position;
		}
		Instantiate(objs[selection], lastPlatformPosition + displacementVector, Quaternion.identity, platformParent.transform);
		// ################ NY ################
	}
			
}
