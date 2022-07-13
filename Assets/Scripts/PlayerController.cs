using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("For Movement")]
    [SerializeField] private float movementSpeed;
    private float movementInputDirection;
    private bool isFacingRight = true;
    private bool isRunning;

    [Space(10)]


    [Header("For Jumping")]
    [SerializeField] private int amountOfJump = 1;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    private int amountOfJumpLeft;
    private bool isGrounded;
    private bool canJump;

    [Space(10)]

    [Header("For Wall Sliding")]
    [SerializeField] private float wallSlidingSpeed;
    [SerializeField] private float wallCheckDistance;
    private bool isTouchingWall;
    private bool isWallSliding;

    [Space(10)]

    [Header("For Wall Jumping")]
    [SerializeField] private float wallJumpForce = 18f;
    private bool canWallJump;

    [Space(10)]

    [Header("For Particle Effects")]
    [SerializeField] private ParticleSystem runningDust;
    [SerializeField] private ParticleSystem wallSlidingDust;

    private Rigidbody2D rb;
    private Animator anim;

    [Space(10)]

    [Header("Other")]

    [SerializeField] private float invisibleTime = 1f;
    [HideInInspector] public bool canTakeDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        amountOfJumpLeft = amountOfJump;
        canTakeDamage = true;
    }
    
    void Update()
    {
        CheckInput();   
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();
        CheckParticleSystem();
        CheckForPlayerDie();
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

        isTouchingWall = Physics2D.Raycast(transform.position, transform.right, wallCheckDistance, groundLayer);
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

    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (amountOfJumpLeft == 1)
            {
                anim.Play("DoubleJump");
            }
            
            amountOfJumpLeft--;
        }

        if (canWallJump && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, wallJumpForce);

            //if (movementInputDirection == 0)
            //{
            //    rb.AddForce(new Vector2(-wallJumpDirection * wallBounceForce * xPushIndex, yPushIndex));
            //}
            //else
            //{
            //    rb.AddForce(new Vector2(-movementInputDirection * wallBounceForce * xPushIndex, yPushIndex));
            //}
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
            //wallJumpDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y, transform.position.z));
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canTakeDamage && collision.gameObject.CompareTag("Trap"))
        {
            if (HealthManager.Instance.currentHealth != 0)
            {
                PlayerGetHit();
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (HealthManager.Instance.currentHealth != 0)
            {
                PlayerGetHit();
            } 
        }
    }

    public void PlayerGetHit()
    {
        canTakeDamage = false;
        anim.Play("Hit");
        HealthManager.Instance.currentHealth--;
        StartCoroutine(ResetTakeDamage());
    }

    IEnumerator ResetTakeDamage()
    {
        yield return new WaitForSeconds(invisibleTime);

        canTakeDamage = true;
    }

    private void CheckForPlayerDie()
    {
        if (HealthManager.Instance.currentHealth <= 0)
        {
            CinemachineShake.Instance.Shake(5f, 0.15f);
            PlayerDisappear();
        }
    }

    public void PlayerDie() // trigger in disappear animation
    {
        Destroy(gameObject);
    }

    private void PlayerDisappear()
    {
        anim.Play("Disappear");
        GetComponent<Collider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
