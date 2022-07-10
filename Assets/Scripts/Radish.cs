using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radish : MonoBehaviour
{
    private Rigidbody2D rb;
    private WallToWall wallToWall;
    private WallToWallPatrollAnimation animationController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        wallToWall = GetComponent<WallToWall>();
        animationController = GetComponent<WallToWallPatrollAnimation>();
    }

    private void Start()
    {
        MovementExecution(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            MovementExecution(true);

            Destroy(rb);
        }
    }

    private void MovementExecution(bool trueOrFalse)
    {
        wallToWall.enabled = trueOrFalse;
        animationController.enabled = trueOrFalse;
    }
}
