using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limmitDis = 20f;
    public float respawnDis = 40f;
    float firstCheck;

    private void Awake()
    {
        firstCheck = player.transform.position.x;
    }

    protected void FixedUpdate()
    {
        this.GetDistance();
        this.Spawning();
    }
    protected void Spawning()
    {
        if(this.currentDis < this.limmitDis)
        {
            return;
        }
        Debug.Log("Spawn");
        Vector3 pos = transform.position;
        if(Player.spawn == true)
        {
            pos.x = firstCheck;
        }
        pos.x += this.respawnDis;
        transform.position = pos;
    }
    protected virtual void GetDistance()
    {
        this.currentDis = this.player.position.x - transform.position.x;
    }

}
