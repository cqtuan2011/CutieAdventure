using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockHead : MonoBehaviour
{
    [SerializeField] private float movingDuration = 2f;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform leftWallPoint;
    [SerializeField] private Transform rightWallPoint;
    [SerializeField] private AnimationCurve curve;

    private Animator anim;

    public Transform[] wayPoints;
    private int currentWaypointIndex = 0;
    private Vector2 currentPos;
    private Vector2 targetPos;
    
    private float elapsedTimer;

    public bool leftWallChecked;
    public bool rightWallChecked;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currentPos = wayPoints[currentWaypointIndex].position;
        targetPos = wayPoints[currentWaypointIndex + 1].position;
    }

    private void Update()
    {
        Move();
        WallCheckHit();
        UpdateAnimation();
    }

    private void Move()
    {
        elapsedTimer += Time.deltaTime;

        float percentageComplete = elapsedTimer / movingDuration;

        if (Vector2.Distance(transform.position, targetPos) < .2f)
        {
            currentPos = targetPos;
            targetPos = wayPoints[currentWaypointIndex].position;
        }

        transform.position = Vector2.Lerp(currentPos, targetPos, curve.Evaluate(percentageComplete));

        //transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, curve.Evaluate());
    }

    private void UpdatePosition()
    {
        currentPos = wayPoints[currentWaypointIndex].position;
        targetPos = wayPoints[currentWaypointIndex + 1].position;
    }

    private void UpdateAnimation()
    {
        anim.SetBool("leftHit", leftWallChecked);
        anim.SetBool("rightHit", rightWallChecked);
    }

    public void WallCheckHit()
    {
        leftWallChecked = Physics2D.Raycast(leftWallPoint.position, Vector2.left, wallCheckDistance, groundLayer);
        rightWallChecked = Physics2D.Raycast(rightWallPoint.position, Vector2.right, wallCheckDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(leftWallPoint.position, new Vector3(leftWallPoint.position.x - wallCheckDistance, leftWallPoint.position.y, leftWallPoint.position.z));
        Gizmos.DrawLine(rightWallPoint.position, new Vector3(rightWallPoint.position.x + wallCheckDistance, rightWallPoint.position.y, rightWallPoint.position.z));
    }
}
