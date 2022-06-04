using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float movementInputDirection;

    private int amountOfJumpLeft;

    private bool isFacingRight = true;
    private bool isRunning;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool canJump;
    private bool canWallJump;
    public bool isTouchingRockHead;

    public int amountOfJump = 1;

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float wallSlidingSpeed;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private ParticleSystem runningDust;
    [SerializeField] private ParticleSystem wallSlidingDust;

    public Transform groundCheck;
    public Transform wallCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        amountOfJumpLeft = amountOfJump;
    }

    
    void Update()
    {
        CheckInput();   
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();
        CheckParticleSystem();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    private void CheckIfWallSliding()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
        } else
        {
            isWallSliding = false;
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, groundLayer);
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0.1f)
        {
            amountOfJumpLeft = amountOfJump;
        }

        if (amountOfJumpLeft <= 0)
        {
            canJump = false;
        } else
        {
            canJump = true;
        }

        if (isTouchingWall)
        {
            canWallJump = true;
        } else if (!isTouchingWall)
        {
            canWallJump = false;
        }
    } 
    
    private void CheckParticleSystem()
    {
        if (isRunning && isGrounded)
        {
            runningDust.Play();
        }
    }
    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        } else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if (movementInputDirection != 0)
        {
            isRunning = true;
        }
        else 
            isRunning = false;
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isWallSliding", isWallSliding);
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (canJump || canWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            amountOfJumpLeft--;
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementInputDirection * movementSpeed, rb.velocity.y);

        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlidingSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
                wallSlidingDust.Play();
            }
        }
    }

    private void Flip()
    {
        if (!isWallSliding)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerDisappear();
        }

        if (collision.gameObject.CompareTag("Trampoline") && isGrounded)
        {
            rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        }
    }

    private void PlayerDie() // trigger in disappear animation
    {
        Destroy(gameObject);
    }

    public void PlayerDisappear()
    {
        anim.Play("Disappear");
        rb.bodyType = RigidbodyType2D.Static;
    }
}
