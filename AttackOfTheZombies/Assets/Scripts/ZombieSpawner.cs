using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour

{
    public Transform[] spawnPositions;
    public GameObject zombie;
    
    public float currentSpawnRate = 0;
    private bool stopSpawning = false;
    

    void Update()
    {
        zombieSpawnFunction(currentSpawnRate);
      
    }

    public void zombieSpawnFunction(float delay)
    {
        if (stopSpawning == false)
        {
            StartCoroutine(SpawnZombies(delay));
        }
    }



    IEnumerator SpawnZombies(float delay)
    {
        stopSpawning = true;
        yield return new WaitForSeconds(delay);    //timeBeforespawning is the delay
        Instantiate(zombie, spawnPositions[0].transform.position, Quaternion.identity);   //Spawn zombies at a specific position
        stopSpawning = false;
    }

   

}
