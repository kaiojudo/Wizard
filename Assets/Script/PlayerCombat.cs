using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamageJ = 40;
    [SerializeField] AudioSource src;
    [SerializeField] int attackDamageK = 80;
    [SerializeField] int attackDamageL = 100;
    [SerializeField] AudioClip atkJ;
    [SerializeField] AudioClip atkK;
    [SerializeField] AudioClip atkL;
    protected bool checkAtkL = false;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            if (EventManager.checkAudio)
            {
                src.clip = atkJ;
                src.Play();
            }
            AtkJ();
        }
        if (Input.GetKeyDown(KeyCode.K) && Player.currentStamina >=20)
        {
            if (EventManager.checkAudio)
            {
                src.clip = atkK;
                src.Play();
            }
            AtkK();
        }
        if (Input.GetKeyDown(KeyCode.L) && Player.currentStamina >= 40)
        {
            if (EventManager.checkAudio)
            {
                src.clip = atkL;
                src.Play();
            }
            AtkL();
        }
     
    }
    void AtkJ()
    {
        animator.SetTrigger("isAtkJ");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Monster>())
            {
                enemy.GetComponent<Monster>().TakeDamage(attackDamageJ);
            }
            if (enemy.GetComponent<Boss>())
            {

                enemy.GetComponent<Boss>().TakeDamage(attackDamageK);
            }
        }
    }
    void AtkK()
    {
        animator.SetTrigger("isAtkK");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Monster>())
            {
                enemy.GetComponent<Monster>().TakeDamage(attackDamageK);
            }
            if (enemy.GetComponent<Boss>())
            {

                enemy.GetComponent<Boss>().TakeDamage(attackDamageK);
            }
        }
        Player.currentStamina -= 20;


    }
    void AtkL()
    {
        animator.SetTrigger("isAtkL");
        if(transform.localScale.x > 0)
        {
            attackPoint.position += new Vector3(1, 0, 0);

        }
        else
            attackPoint.position += new Vector3(-1, 0, 0);


        checkAtkL = true;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Monster>())
            {
                enemy.GetComponent<Monster>().TakeDamage(attackDamageL);
            }
            if(enemy.GetComponent<Boss>()) { 
            
                enemy.GetComponent<Boss>().TakeDamage(attackDamageL);
            }
        }
        Player.currentStamina -= 40;
        Invoke("CheckAtkL", 1f);

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void CheckAtkL()
    {
        if (checkAtkL)
        {
            checkAtkL = false;
            if(transform.localScale.x > 0)
            {
                attackPoint.position += new Vector3(-1, 0, 0);

            }
            else
            attackPoint.position += new Vector3(1, 0, 0);

        }
    }
}
