using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public AudioSource src;
    public AudioClip pickCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            src.clip = pickCoin;
            src.Play();
            Destroy(gameObject);
            Player.point += 150;
            Player.pointtoHp += 150;
            Player.GetLife();
        }
    }
}
