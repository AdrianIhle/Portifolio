using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour {

	public GameObject projectile;															//used to insert a reference to the prefab projectile
	public GameObject ProjectileSpawner;													//used to create a reference to the game object ProjectileSpawner
	public float translation = 1f;
	public AudioSource shooting;
	public AudioClip MagicMissile;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void shoot()																		//whne activated, produces an instance/copy of the prefab 'projectile' that spawns at the gameobjects position
	{
		StartCoroutine (BulletDelaySpawn ());

	}
	IEnumerator BulletDelaySpawn(){
		yield return new WaitForSeconds (0.4f);
		Instantiate (projectile,ProjectileSpawner.transform.position, Quaternion.identity);

	}
}
