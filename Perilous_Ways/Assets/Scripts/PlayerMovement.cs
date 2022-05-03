using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float dirX;
    private bool facingright = true;
    private Vector3 localScale;

    public Rigidbody2D rb;
    public Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool isGrounded = false;
    public bool doubleJump;
    public float MoveSpeed = 10f;
    public float JumpForce = 8f;
    public SpriteRenderer sr;
    public Animator anim;
    public float move;
    private bool shouldJump= false;

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        
    }

    void Update()
    {

        // for playing with keyboard
        // move = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2 (move*MoveSpeed, rb.velocity.y);

        // if(Input.GetKeyDown(KeyCode.D)){
        //     sr.flipX = false;
        // }
        // else if(Input.GetKeyDown(KeyCode.A)){
        //     sr.flipX = true;
        // }

        // else if(Input.GetKeyDown(KeyCode.W)){
        //     if(isGrounded){
        //         jumpSoundEffect.Play();
        //         rb.velocity = new Vector2(rb.velocity.x,JumpForce);
        //         doubleJump = true;
        //     }
        //     else if (doubleJump){
        //         jumpSoundEffect.Play();
        //         rb.velocity = new Vector2(rb.velocity.x,JumpForce);
        //         doubleJump = false;
        //     }
        // }
        // // for running
        // if(move > 0f)
        // {
        //     anim.SetBool("running",true);
        // }
        // else if(move < 0f)
        // {
        //     anim.SetBool("running",true);
        // }
        // else
        // {
        //     anim.SetBool("running",false);
        // }


        //for android
        dirX = CrossPlatformInputManager.GetAxis("Horizontal")*MoveSpeed;

        if(Mathf.Abs(dirX) > 0 && rb.velocity.y ==0)
            anim.SetBool("running",true);
        else
            anim.SetBool("running",false);


        //for jumping
        if(rb.velocity.y > 0.1f){
            anim.SetBool("jumping",true);
        }
        else{
            anim.SetBool("jumping",false);
        }
        GroundCheck();
    }
    
    public void GroundCheck(){
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position,groundCheckRadius,groundLayer);
        if(colliders.Length > 0){
            isGrounded = true;
        }
    }

    public void Jump(){
        if(isGrounded){
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x,JumpForce);
                doubleJump = true;
            }
            else if (doubleJump){
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x,JumpForce);
                doubleJump = false;
            }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if(dirX > 0)
            facingright = true;
        else if(dirX < 0)
            facingright = false;

        if(((facingright) && localScale.x < 0 ) || ((!facingright) && localScale.x > 0))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

}
