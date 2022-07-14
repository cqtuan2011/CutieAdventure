using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : MonoBehaviour
{
    [SerializeField] private AIOverlapDetector detector;
    [SerializeField] private float chasingSpeed;
    [SerializeField] private Transform playerToFollow;

    private Animator anim;

    private Vector3 tmpScale;
    private Vector3 startPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = transform.position;
        tmpScale = transform.localScale;
    }

    private void Update()
    {
        if (detector.playerInArea)
        {
            ChasingTarget(playerToFollow.position);
        } else if (!detector.playerInArea && transform.position != startPos)
        {
            ReturnStartPosition(startPos);
        }
    }


    private void FlyTowardsTarget(Vector3 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, chasingSpeed * Time.deltaTime);
    }

    private void FacingTowardsTarget(Vector3 target)
    {

        if (transform.position.x < target.x) // player is standing at the right side of the target
        {
            tmpScale.x = -1;
        } else
        {
            tmpScale.x = 1;
        }

        transform.localScale = tmpScale;
    }

    private void ChasingTarget(Vector3 target)
    {
        anim.SetTrigger("ceilingOut");
        FlyTowardsTarget(target);
        FacingTowardsTarget(target);
    }

    private void ReturnStartPosition(Vector3 startPosition)
    {
        FlyTowardsTarget(startPosition);
        FacingTowardsTarget(startPosition);

        if (Vector2.Distance(transform.position, startPosition) < 0.2f)
        {
            anim.SetTrigger("ceilingIn");
        }
    }
}
