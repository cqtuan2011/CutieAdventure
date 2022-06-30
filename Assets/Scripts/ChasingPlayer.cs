using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIOverlapDetector))]
public class ChasingPlayer : MonoBehaviour
{
    private AIOverlapDetector detector;
    private EnemyPatrolling patroll;
    private Animator anim;

    [SerializeField] private Transform playerToFollow;
    [SerializeField] private float enemyChasingSpeed;

    private Vector3 playerPos;
    private bool isMoving;

    private void Awake()
    {
        detector = GetComponent<AIOverlapDetector>();
        patroll = GetComponent<EnemyPatrolling>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
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
        if (detector.playerInHitArea)
        {
            isMoving = false;
            anim.SetTrigger("Attack");
            enemyChasingSpeed = 0;
        }
        else
        {
            isMoving = true;
        }
    }
}
