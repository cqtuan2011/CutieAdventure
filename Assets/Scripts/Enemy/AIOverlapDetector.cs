using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOverlapDetector : MonoBehaviour
{
    [SerializeField] private Vector3 detectorSize;
    [SerializeField] private Vector3 positionOffset;

    [Space(10)]

    public LayerMask playerLayer;
    public Color gizmosColor;
    public Color detectedColor;

    public bool drawGizmos;
    
    [HideInInspector] public bool playerInArea;
    private void Update()
    {
        CheckSurrounding();
    }

    private void CheckSurrounding()
    {
        playerInArea = Physics2D.OverlapBox(transform.position + positionOffset, detectorSize, 0, playerLayer);
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
        }
    }
}
