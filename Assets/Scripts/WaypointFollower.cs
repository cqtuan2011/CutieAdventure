using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public float movingSpeed = 2f;

    [HideInInspector] public Transform firstPointPos;
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private bool enemyModeFlip;
    [SerializeField] private bool trapModePatroll;
    [SerializeField] private bool randomWaypointIndex;
    [SerializeField] private float waitTime = 1f;

    private int currentWaypointIndex;
    private float timer;


    private void Start()
    {
        firstPointPos = wayPoints[0].transform;
        timer = waitTime;
        RandomFirstWaypointIndex();
    }

    void Update()
    {
        WaypointFollow();
    }

    private void WaypointFollow()
    {
        if (Vector2.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position) < .2f)
        {
            TrapModePatrolling();

            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        if (enemyModeFlip) // to flip enemy to the right direction
        {
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime * movingSpeed);
    }

    private void Flip()
    {
        Vector3 tmpScale = gameObject.transform.localScale;

        if (wayPoints[currentWaypointIndex].transform.position.x < transform.position.x)
        {
            tmpScale.x = 1;
        }
        else
        {
            tmpScale.x = -1;
        }
        gameObject.transform.localScale = tmpScale;
    }

    private void TrapModePatrolling()
    {
        if (trapModePatroll)
        {
            TrapModeTimer();
        } else
        {
            currentWaypointIndex++;
        }
    }

    private void TrapModeTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            currentWaypointIndex++;
            timer = waitTime;
        }
    }

    private void RandomFirstWaypointIndex()
    {
        if (randomWaypointIndex)
        {
            int index = Random.Range(0, wayPoints.Length);
            currentWaypointIndex = index;
        } else
        {
            currentWaypointIndex = 0;
        }
    }
}
