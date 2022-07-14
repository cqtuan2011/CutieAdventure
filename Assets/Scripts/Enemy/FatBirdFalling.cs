using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdFalling : MonoBehaviour
{
    [SerializeField] private float fallingSpeed = 3.5f;
    [SerializeField] private float resetPosSpeed;
    [SerializeField] private float groundWaitTime;
    [SerializeField] private ParticleSystem slamDustPS;
    [SerializeField] private float groundCheckLength;
    [SerializeField] private LayerMask groundLayer;

    private AIOverlapDetector detector;
    private WaypointFollower waypointFollower;
    private Animator anim;
    private Transform firstWaypoint;

    private bool isFalling;
    private bool isGrounded;

    private float initialSpeed;

    private void Awake()
    {
        detector = GetComponent<AIOverlapDetector>();
        waypointFollower = GetComponent<WaypointFollower>();
        anim = GetComponent<Animator>();    
    }

    private void Start()
    {
        initialSpeed = waypointFollower.movingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        DangerCheck();
        FallMovement();
        CheckSurrounding();
        CheckGround();
        ResetWaypointSpeed();
    }

    private void DangerCheck()
    {
        if (detector.playerInArea)
        {
            waypointFollower.enabled = false;

            Fall();
        }
    }

    private void CheckSurrounding()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector3.down, groundCheckLength, groundLayer);
    }
    private void FallMovement()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
        }
    }

    private void Fall()
    {
        isFalling = true;
        anim.Play("Fall");
    }

    private void CheckGround()
    {
        if (isGrounded)
        {
            isFalling = false;
            slamDustPS.Play();
            anim.SetTrigger("Ground");
            StartCoroutine(EnableWaypointSystem());
        }
    }

    IEnumerator EnableWaypointSystem()
    {
        yield return new WaitForSeconds(groundWaitTime);

        waypointFollower.enabled = true;
        waypointFollower.movingSpeed = resetPosSpeed;
    }

    private void ResetWaypointSpeed()
    {
        if (Vector2.Distance(transform.position, waypointFollower.firstPointPos.position) < 0.2f)
        {
            waypointFollower.movingSpeed = initialSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckLength)); 
    }
}
