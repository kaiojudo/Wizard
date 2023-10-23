using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    protected int maxHealth = 100;
    protected int curentHealth;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] Transform player;
    public float speed = 2;


    void Start()
    {
        curentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
    }
    void Update()
    {

        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }
    void LateUpdate()
    {
        if (curentHealth <= 0)
        {
            speed = 0;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          Vector3 check = transform.position - player.position;
            if(check.x < 0 && currentPoint == pointB.transform) {
                Flip();
                rb.velocity = new Vector2(speed, 0);
                currentPoint = pointA.transform;

            }
            if (check.x > 0 && currentPoint == pointA.transform)
            {
                Flip();
                rb.velocity = new Vector2(-speed, 0);
                currentPoint= pointB.transform;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        animator.SetTrigger("Hurt");
        speed = 0;
        Invoke("GetHurt", 0.5f);
        if (curentHealth <= 0)
        {
            Die();
            if (Player.currentStamina < 80)
            {
                Player.currentStamina += 20;
                
            }
            if(Player.currentStamina > 80) {
                Player.currentStamina = 100;
            }
            Player.point += 200;
            Player.pointtoHp += 200;
            Player.GetLife();
        }
    }
    void Die()
    {
        animator.SetBool("isDeath", true);
        GetComponent<Collider2D>().enabled = false;
        /*  this.enabled = false;*/

    }
    void GetHurt()
    {
        speed = 2;
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
    
}
