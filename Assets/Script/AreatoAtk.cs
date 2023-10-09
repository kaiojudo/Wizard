using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreatoAtk : MonoBehaviour
{
    [SerializeField] private GameObject objecttoSpawn;
    [SerializeField] private Transform player;
    [SerializeField] private float timeToSpawn;
    private float currentTimeToSpawn;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float checkBoss = Vector2.SqrMagnitude(transform.position - player.position);
        Debug.Log(checkBoss);
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else if(checkBoss < 10000)
        {
            SpawnEnemy();
            currentTimeToSpawn = timeToSpawn;
            /*objecttoSpawn.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed + Time.deltaTime);*/
        }

    }
    void SpawnEnemy()
    {
        Instantiate(objecttoSpawn, transform.position, transform.rotation);
    }
    
}
