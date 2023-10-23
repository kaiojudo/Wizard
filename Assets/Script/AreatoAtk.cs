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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 check = transform.position - player.position;
            if (check.x > 0)
            {
                player.position -= new Vector3(1, -1, 0) / 2;
            }
            if (check.x < 0)
            {
                player.position -= new Vector3(-1, -1, 0) / 2;
            }
        }
    }
}
