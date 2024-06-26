using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private Animator animator;
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Transform trans;

    private int jumpsLeft;
    private float initspeed;

    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip dashSound;

    private void Start(){
        Time.timeScale = 1f;
        jumpsLeft = maxJumps;
        animator =  GetComponent<Animator>();
        initspeed = speed;
        trans = this.transform;
    }

    private void Update()
    {
        
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded()){
            animator.SetBool("isGround",true); 
            if (rb.velocity.y <= 1e-3)
                jumpsLeft = maxJumps;    
        }else{
            animator.SetBool("isGround",false); 
        }

        if (Input.GetButtonDown("Jump") && jumpsLeft >= 1 )
        {    
            src.PlayOneShot(jumpSound);      
            animator.SetBool("isGround",false); 
            jumpsLeft -= 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);   
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            src.PlayOneShot(dashSound);
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            animator.SetBool("dashing",true);
            return;
        }else{
            animator.SetBool("dashing",false);
        }

        rb.velocity = new Vector2(horizontal * initspeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void changeSpeed(float a){
        initspeed = (speed/a);

    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public bool CanAttack(){
        return IsGrounded() && !isDashing;
    }
}