using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOverlapDetector : MonoBehaviour
{
    [SerializeField] Vector3 detectorSize;
    [SerializeField] Vector3 positionOffset;

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
            Gizmos.color = gizmosColor;
            Gizmos.DrawCube(transform.position + positionOffset, detectorSize);
        }
    }
}
