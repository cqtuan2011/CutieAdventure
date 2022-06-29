using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private bool isHit;
    private Animator anim;

    [SerializeField] private float fallingSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isHit)
        {
            transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Hit");
            isHit = true;

            DisableZigzagMovement();
            DisablePatrolling();
            DisableWaypointFollower();
            DisableEnemyShootingBehaviour();
        }
    }

    private void DisableZigzagMovement()
    {
        if (GetComponent<ZigzagMovement>() != null)
        {
            GetComponent<ZigzagMovement>().enabled = false;
        }
    } 

    private void DisablePatrolling()
    {
        if (GetComponent<EnemyPatrolling>() != null)
        {
            GetComponent<EnemyPatrolling>().enabled = false;
        }
    }

    private void DisableEnemyShootingBehaviour()
    {
        if (GetComponent <EnemyShootingBehaviour>() != null)
        {
            GetComponent<EnemyShootingBehaviour>().enabled = false;
        }
    }

    private void DisableWaypointFollower()
    {
        if (GetComponent<WaypointFollower>() != null)
        {
            GetComponent <WaypointFollower>().enabled = false;
        }
    }
}
