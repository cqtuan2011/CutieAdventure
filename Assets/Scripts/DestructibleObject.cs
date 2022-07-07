using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] private int health = 2;
    [SerializeField] private GameObject destructibleRef;
    [SerializeField] private GameObject dustParticle;
    [SerializeField] private float bounciness;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, bounciness);
            health--;
            anim.Play("Hit");
        }

        if (health <= 0)
        {
            DestroyGameObject();
        }
    }

    private void DestroyGameObject()
    {
        GameObject newObject = Instantiate(destructibleRef);
        GameObject particle = Instantiate(dustParticle);

        newObject.transform.position = transform.position;
        particle.transform.position = transform.position;

        Destroy(this.gameObject);
    }
}
