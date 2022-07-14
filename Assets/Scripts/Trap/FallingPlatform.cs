using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("PlayerOn");
        }
    }

    private void Falling() // function called in the end of "PlayerOn" animation
    {
        anim.enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
