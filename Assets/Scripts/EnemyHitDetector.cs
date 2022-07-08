using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetector : MonoBehaviour
{
    [SerializeField] private Vector3 hitBoxSize;
    [SerializeField] private Vector3 positionOffset;

    [Space(10)]

    public LayerMask playerLayer;
    public Color gizmosColor;
    public Color detectedColor;

    public bool drawGizmos;

    [HideInInspector] public bool playerInHitArea;
    private void Update()
    {
        CheckSurrounding();
    }

    private void CheckSurrounding()
    {
        playerInHitArea = Physics2D.OverlapBox(transform.position + positionOffset, hitBoxSize, 0, playerLayer);
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            if (!playerInHitArea)
            {
                Gizmos.color = gizmosColor;
            }
            else
            {
                Gizmos.color = detectedColor;
            }
            Gizmos.DrawCube(transform.position + positionOffset, hitBoxSize);
        }
    }
}
