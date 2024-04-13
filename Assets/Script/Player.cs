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
    public static bool spawn = false;
    public int maxHealth = 100;
    public static int currentHealth = 100;
    public int maxStamina = 100;
    public static int currentStamina = 100;
    [SerializeField] HealthBar healthBar;
    [SerializeField] StaminaBar staminaBar;
    [SerializeField] Animator animator;
    [SerializeField] GameObject gameOverUI;
    public static int currentScene = 1;
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip dieEff;
    [SerializeField] AudioClip takeDmgEff;
    public Vector3 respawnPoint;
    public static int point = 0;
    public static int pointtoHp = 0;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        staminaBar.SetMaxStamina(maxStamina);
        staminaBar.SetStamina(currentStamina);
        respawnPoint = transform.position;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void Update()
    {
        healthBar.SetHealth(currentHealth);
        staminaBar.SetStamina(currentStamina);

    }
    private void FixedUpdate()
    {
     
        timer += Time.deltaTime;
        if(currentStamina < 100 && currentHealth>0 && timer > 1)
        {
            timer -= 1;
            currentStamina++;

        }
       
    }
    public static void GetLife()
    {
        if(pointtoHp >= 2000)
        {
            life += 1;
            pointtoHp = pointtoHp - 2000;
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
            animator.SetTrigger("isHurt");
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
            animator.SetTrigger("isHurt");
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
            animator.SetTrigger("isHurt");
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
            currentStamina = maxStamina;

        }
        if (life == 0)
        {
            Die();
        }
    }


}
