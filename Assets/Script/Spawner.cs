using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objecttoSpawn;
    [SerializeField] private float timeToSpawn;
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
