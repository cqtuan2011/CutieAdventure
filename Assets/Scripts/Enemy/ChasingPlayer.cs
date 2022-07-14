using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayer : MonoBehaviour
{
    private EnemyPatrolling patroll;
    private Animator anim;
    private EnemyHitDetector hitDetector;

    [SerializeField] private AIOverlapDetector detector;
    [SerializeField] private Transform playerToFollow;
    [SerializeField] private float enemyChasingSpeed;
    [SerializeField] private bool attackType;

    private Vector3 playerPos;
    private bool isMoving;


    private float initialChasingSpeed;

    private void Awake()
    {
        patroll = GetComponent<EnemyPatrolling>();
        anim = GetComponent<Animator>();
        
        if (attackType)
        {
            hitDetector = GetComponent<EnemyHitDetector>();
        }
    }

    private void Start()
    {
        initialChasingSpeed = enemyChasingSpeed;
    }

    private void Update()
    {
        isMoving = patroll.isMoving;
        SearchForPlayer();

        UpdateAnimation();

        if (playerToFollow != null)
            UpdatePlayerPosition();
        else return;
        
    }
    private void UpdateAnimation()
    {
        anim.SetBool("isMoving", isMoving);
    }
    private void CheckDirection()
    {
        Vector3 tmpScale = transform.localScale;

        if (transform.position.x < playerToFollow.position.x)
        {
            tmpScale.x = -1;
        }
        else
        {
            tmpScale.x = 1;
        }
        transform.localScale = tmpScale;
    }

    private void SearchForPlayer()
    {
        if (detector.playerInArea)
        {
            GetComponent<WaypointFollower>().enabled = false;
            GetComponent<EnemyPatrolling>().enabled = false;
            CheckDirection();
            transform.position = Vector2.MoveTowards(transform.position, playerPos, enemyChasingSpeed * Time.deltaTime);
            isMoving = true;

            if (!attackType) return; 
            
            CheckPlayerInHitArea();
        }
        else
        {
            GetComponent<WaypointFollower>().enabled = true;
            GetComponent<EnemyPatrolling>().enabled = true; 
        }
    }

    private void UpdatePlayerPosition()// this function will avoid enemy from flying up (only for ground-type enemy)
    {
        playerPos = new Vector3(playerToFollow.position.x, transform.position.y, 0);
    }

    private void CheckPlayerInHitArea()
    {
        if (hitDetector.playerInHitArea)
        {
            isMoving = false;
            anim.SetTrigger("Attack");
            enemyChasingSpeed = 0;
        }
        else
        {
            enemyChasingSpeed = initialChasingSpeed;
            isMoving = true;
        }
    }
}
