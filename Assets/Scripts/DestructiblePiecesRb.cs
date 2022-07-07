using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePiecesRb : MonoBehaviour
{
    [SerializeField] private Vector2 forceDirection;
    [SerializeField] private float torque;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        float randTorque = Random.Range(-100, 100);
        float randForceX = Random.Range(forceDirection.x - 50, forceDirection.x + 50);
        float randForceY = Random.Range(forceDirection.y - 50, forceDirection.y + 50);

        forceDirection.x = randForceX;
        forceDirection.y = randForceY;

        rb.AddForce(forceDirection);
        rb.AddTorque(torque);

        Invoke("DestroySelf", Random.Range(2, 5));
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
