using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSaw : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 360 * rotatingSpeed * Time.deltaTime);
    }
}
