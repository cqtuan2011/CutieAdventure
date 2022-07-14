using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float force = 25f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("Push");
            var playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            playerRb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }
}
