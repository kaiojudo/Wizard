using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int life = 2;
    public int maxHealth = 100;
    public static int currentHealth = 100;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Animator animator;
    [SerializeField] GameObject gameOverUI;
    public static int currentScene = 1;
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip dieEff;
    [SerializeField] AudioClip takeDmgEff;
    public Vector3 respawnPoint;
    public static int point = 0;
    public static int pointtoHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        respawnPoint = transform.position;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public static void GetLife()
    {
        if(pointtoHp > 2000)
        {
            life += 1;
            pointtoHp = point - 2000;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            life -= 1;
            SpawnAgain();
        }


        if (collision.gameObject.CompareTag("Monster"))
        {
            if (EventManager.checkAudio)
            {
                src.clip = takeDmgEff;
                src.Play();
            }
            TakeDamage(20);
            if (currentHealth <= 0)
            {
                life -= 1;
                SpawnAgain();
            }

        }
    
        if (collision.gameObject.CompareTag("NextScene"))
        {
            currentScene++;
            point += 500;
            pointtoHp += 500;
            GetLife();
            SceneManager.LoadScene("LV" + currentScene);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (EventManager.checkAudio)
            {
                src.clip = takeDmgEff;
                src.Play();
            }
            TakeDamage(10);
            if (currentHealth <= 0)
            {
                life -= 1;
                SpawnAgain();
            }
            Destroy(collision.gameObject);


        }
        if (collision.gameObject.CompareTag("MiniBoss"))
        {
            if (EventManager.checkAudio)
            {
                src.clip = takeDmgEff;
                src.Play();
            }
            TakeDamage(25);
            if (currentHealth <= 0)
            {
                life -= 1;
                SpawnAgain();
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
        }
   
    }
    private void Die()
    {
        if (EventManager.checkAudio)
        {
            src.clip = dieEff;
            src.Play();
        }
        currentHealth = 0;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("isDeath");
        Invoke("GameOver", 1f);
    }
    private void GameOver()
    {
       
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    private void SpawnAgain()
    {
       if(life > 0)
        {
            transform.position = respawnPoint;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);

        }
        if (life == 0)
        {
            Die();
        }
    }


}
