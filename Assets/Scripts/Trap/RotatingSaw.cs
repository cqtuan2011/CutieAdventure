using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSaw : MonoBehaviour
{
    public bool reverse;
    [SerializeField] private float rotatingSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (reverse)
            transform.Rotate(0f, 0f, 360 * rotatingSpeed * Time.deltaTime);
        else
            transform.Rotate(0f, 0f, 360 * -1 * rotatingSpeed * Time.deltaTime);
    }
}
