using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockHead : MonoBehaviour
{
    [SerializeField] private float movingDuration = 2f;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform leftWallPoint;
    [SerializeField] private Transform rightWallPoint;
    [SerializeField] private Ease ease;

    private Animator anim;
    private Rigidbody2D rb;

    public bool leftWallChecked;
    public bool rightWallChecked;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Move();
    }

    private void Update()
    {
        WallCheckHit();
        UpdateAnimation();
    }

    private void Move()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(new Vector3(-15, -5, 0), movingDuration).SetEase(ease))
            .Append(transform.DOMove(new Vector3(-30, -5, 0), movingDuration).SetEase(ease));
        sequence.SetLoops(-1, LoopType.Restart);
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
