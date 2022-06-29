using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLifeTime = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BulletDisappear", bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Camera"))
        {
            BulletDisappear();
        } 
    }

    private void BulletDisappear()
    {
        Destroy(gameObject);
    }
}
