using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator animator;
    protected int maxHealth = 300;
    protected int curentHealth;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private Transform player;


    private float timer;
    private void Start()
    {   

        curentHealth = maxHealth;
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        float checkBoss = Vector2.SqrMagnitude(this.transform.position - player.position);
        timer += Time.deltaTime;
        if(curentHealth > 0)
        {
            if (checkBoss <= 30)
            {
                if (timer > 3)
                {
                    timer = 0;
                    animator.SetTrigger("isAttack");
                    Shoot();
                }
            }
            Vector2 check = player.position - transform.position;
            if (check.x > 0)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -3f;
                transform.localScale = localScale;
            }
            if (check.x < 0)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = 3f;
                transform.localScale = localScale;
            }
        }
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        animator.SetTrigger("isHurt");
        Debug.Log(curentHealth);
        if (curentHealth <= 0)
        {
            Die();
            if (Player.currentStamina < 60)
            {
                Player.currentStamina += 40;

            }
            Player.point += 500;
            Player.pointtoHp += 500;
            Player.GetLife();
        }
    }
    void Die()
    {
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        /*  this.enabled = false;*/

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
