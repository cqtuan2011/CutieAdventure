using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallToWall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask groundLayer;

    public bool isFacingRight;
    private bool isTouchingWall;
    private Vector3 raycastDirection;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = Random.value > .5f; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckForWalls();
        CheckFlip();
        ObjectMovement();
    }

    private void ObjectMovement()
    {
        transform.Translate(raycastDirection * moveSpeed * Time.deltaTime);
    }

    private void CheckForWalls()
    {
        raycastDirection = (isFacingRight) ? Vector2.right : -Vector2.right;

        isTouchingWall = Physics2D.Raycast(transform.position, raycastDirection, raycastDistance, groundLayer);

        if (isTouchingWall)
        {
            isFacingRight = !isFacingRight;
        }
    }

    private void CheckFlip()
    {
        var tmpScale = transform.localScale;

        tmpScale.x = (isFacingRight) ? -1 : 1;

        transform.localScale = tmpScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + raycastDistance * raycastDirection.x, transform.position.y, transform.position.z));
    }
}
