using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdFalling : MonoBehaviour
{
    [SerializeField] private float fallingSpeed = 3.5f;
    [SerializeField] private ParticleSystem slamDustPS;

    private AIOverlapDetector detector;
    private WaypointFollower waypointFollower;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        detector = GetComponent<AIOverlapDetector>();
        waypointFollower = GetComponent<WaypointFollower>();
        rb = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DangerCheck();
    }

    private void DangerCheck()
    {
        if (detector.playerInArea)
        {
            waypointFollower.enabled = false;
            Fall();
        } 
    }

    private void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = fallingSpeed;
        anim.Play("Fall");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetTrigger("Ground");
            rb.bodyType = RigidbodyType2D.Static;
            EnableWaypointSystem();
            slamDustPS.Play();
        }
    }

    private void EnableWaypointSystem()
    {
        waypointFollower.enabled = true;
    }
}
