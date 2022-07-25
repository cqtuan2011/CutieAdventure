using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockHead : MonoBehaviour
{
    public RockHeadType type;

    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform leftWallPoint;
    [SerializeField] private Transform rightWallPoint;
    [SerializeField] private Transform topWallPoint;
    [SerializeField] private Transform bottomWallPoint;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RockHead"))
        {
            switch (type)
            {
                case RockHeadType.Horizontal:
                    if (collision.gameObject.name == "Waypoint 1")
                    {
                        anim.Play("Left Hit");
                    }
                    else anim.Play("Right Hit");
                    break;

                case RockHeadType.Vertical:
                    if (collision.gameObject.name == "Waypoint 1")
                    {
                        anim.Play("TopHit");
                    }
                    else anim.Play("BottomHit");
                    break;
            }
        }
    }

    public enum RockHeadType
    {
        Horizontal,
        Vertical,
    }
}
