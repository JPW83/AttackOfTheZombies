using UnityEngine;
using System.Collections;

public class Coroutines : MonoBehaviour 
{
	public float zombieSpawnDelay = 0.0f;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			StartCoroutine ("SpawnZombies");	//Starts the coroutine 
		}
	}

	IEnumerator SpawnZombies()	//Name of the coroutine
	{
		yield return new WaitForSeconds(zombieSpawnDelay);	//How long we'll wait
		print ("Spawn zombie");								//What we want to run
		yield return new WaitForSeconds(zombieSpawnDelay);	
		print ("Spawn another zombie");
		yield return null;
	}
}
