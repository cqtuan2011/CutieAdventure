using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallToWallPatrollAnimation : MonoBehaviour
{
    [SerializeField] private float enemyIdleTime;
    [SerializeField] private float enemyMoveTime;

    private Animator anim;
    private WallToWall wallToWall;

    private bool isMoving;
    private float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        wallToWall = GetComponent<WallToWall>();
    }

    private void Start()
    {
        isMoving = true;
        timer = enemyMoveTime;
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
            wallToWall.enabled = false;

            StartCoroutine(EnemyIdleTime());
        }
    }

    IEnumerator EnemyIdleTime()
    {
        yield return new WaitForSeconds(enemyIdleTime);

        wallToWall.enabled = true;
        isMoving = true;
        timer = enemyMoveTime;
    }

    private void UpdateAnimation()
    {
        anim.SetBool("isMoving", isMoving);
    }


}
