using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objecttoSpawn;
    private float timeToSpawn = 1.5f;
    private float currentTimeToSpawn;
    void Update()
    {
      
        if(currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            currentTimeToSpawn = timeToSpawn;
        }
    }
    void SpawnEnemy(){
        Instantiate(objecttoSpawn, transform.position, transform.rotation);
    }
}
