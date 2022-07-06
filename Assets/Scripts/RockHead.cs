using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockHead : MonoBehaviour
{
    [HideInInspector] public bool leftWallChecked;
    [HideInInspector] public bool rightWallChecked;

    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform leftWallPoint;
    [SerializeField] private Transform rightWallPoint;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        WallCheckHit();
        UpdateAnimation();
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
