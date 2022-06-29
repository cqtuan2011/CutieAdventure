using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOverlapDetector : MonoBehaviour
{
    [SerializeField] private Vector3 detectorSize;
    [SerializeField] private Vector3 positionOffset;

    [SerializeField] private Vector3 hitBoxSize;
    [SerializeField] private Vector3 hitBoxPositionOffset;

    public LayerMask playerLayer;
    public Color gizmosColor;
    public Color detectedColor;

    public Color hitBoxColor;

    public bool drawGizmos;
    
    [HideInInspector] public bool playerInArea;
    [HideInInspector] public bool playerInHitArea;
    private void Update()
    {
        CheckSurrounding();
    }

    private void CheckSurrounding()
    {
        playerInArea = Physics2D.OverlapBox(transform.position + positionOffset, detectorSize, 0, playerLayer);
        playerInHitArea = Physics2D.OverlapBox(transform.position + hitBoxPositionOffset, hitBoxSize, 0, playerLayer);
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            if (!playerInArea)
            {
                Gizmos.color = gizmosColor;
            } else
            {
                Gizmos.color = detectedColor;
            }
            Gizmos.DrawCube(transform.position + positionOffset, detectorSize);

            Gizmos.color = hitBoxColor;
            Gizmos.DrawCube(transform.position + hitBoxPositionOffset, hitBoxSize);
        }
    }
}
