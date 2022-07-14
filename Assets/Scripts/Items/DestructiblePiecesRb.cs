using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePiecesRb : MonoBehaviour
{
    [SerializeField] private Vector2 forceDirection;
    [SerializeField] private float torque;
    [SerializeField] private ObjectType objectType;

    private Rigidbody2D rb;
    private float randTorque;
    private float randForceX;
    private float randForceY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        switch (objectType)
        {
            case ObjectType.Object:

                randTorque = Random.Range(-100, 100);
                randForceX = Random.Range(forceDirection.x - 50, forceDirection.x + 50);
                randForceY = Random.Range(forceDirection.y - 50, forceDirection.y + 50);
                break;

            case ObjectType.Enemy:

                int random = Random.Range(1, 3);

                if (random == 1)
                {
                    randForceX = Random.Range(forceDirection.x - 20, forceDirection.x + 20);
                    randTorque = Random.Range(torque - 20, torque + 20);
                } else
                {
                    randForceX = -Random.Range(forceDirection.x - 20, forceDirection.x + 20);
                    randTorque = -Random.Range(torque - 20, torque + 20);
                }
                randForceY = Random.Range(forceDirection.y - 50, forceDirection.y + 50);
                break;
        }

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

    private enum ObjectType
    {
        Object,
        Enemy,
    }
}
