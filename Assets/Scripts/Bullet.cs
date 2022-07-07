using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime = 10f;
    [SerializeField] private GameObject bulletDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BulletDisappear", bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Camera"))
        {
            var bulletPiece = Instantiate(bulletDestroy);

            bulletPiece.transform.position = transform.position; 

            BulletDisappear();
        } 
    }

    private void BulletDisappear()
    {
        Destroy(gameObject);
    }
}
