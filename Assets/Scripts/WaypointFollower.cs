using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private float movingSpeed = 2f;

    private int currentWaypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,wayPoints[currentWaypointIndex].transform.position) < .2f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }  
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime*movingSpeed);
    }
}
