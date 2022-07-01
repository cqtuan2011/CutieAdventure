using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaypointFollower))]
public class EnemyPatrolling : MonoBehaviour
{
    private WaypointFollower waypointFollower;
    private Animator anim;

    private float timer;
    [HideInInspector] public bool isMoving; // use to controll animation 

    // enemy states time for moving and idle 
    [SerializeField] private float enemyMoveDuration = 5f;
    [SerializeField] private float enemyIdleDuration = 3f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        waypointFollower = GetComponent<WaypointFollower>();
    }

    private void Start()
    {
        timer = enemyMoveDuration;
        isMoving = true;
    }

    private void Update()
    {
        EnemyPatrolTimer();
        UpdateAnimation();
    }

    private void EnemyPatrolTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) // out of move duration -> enemy is not moving
        {
            isMoving = false;
            waypointFollower.enabled = false;

            StartCoroutine(EnemyIdleTime());
        }
    }

    IEnumerator EnemyIdleTime()
    {
        yield return new WaitForSeconds(enemyIdleDuration);

        waypointFollower.enabled = true;
        isMoving = true;
        timer = enemyMoveDuration;
    }

    private void UpdateAnimation()
    {
        anim.SetBool("isMoving", isMoving);
    }
}
