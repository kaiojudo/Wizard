using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator animator;
    public AudioSource src;
    public AudioClip jumpEff;
    public bool isLeft;
    public bool isRight;
    public bool isJump;
    void Update()
    {
        Movement();
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
   
        if (isJump && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("isJumping", true);
            if (EventManager.checkAudio)
            {
                src.clip = jumpEff;
                src.Play();

            }
  
        }
        else if(IsGround())
        {
            animator.SetBool("isJumping", false);

        }
        if (!isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            
        }
    }
    public void pointerDownLeft()
    {
        isLeft = true;
    }
    public void pointerDownRight()
    {
        isRight = true;
    }
    public void pointerUpRight()
    {
        isRight = false;
    }
    public void pointerUpLeft()
    {
        isLeft = false;
    }
    public void pointerDownJump()
    {
        isJump = true;
    }
    public void pointerUpJump()
    {
        isJump = false;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal*speed,rb.velocity.y);
        Flip();

    }
    void Movement()
    {
        if (isLeft)
        {
            horizontal = -1;
        }
        else if (isRight)
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f||!isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
}
