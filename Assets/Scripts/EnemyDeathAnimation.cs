using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAnimation : MonoBehaviour
{
    [SerializeField] private GameObject deathBody;
    [SerializeField] private float bodyFallingSpeed = 10f;
    [SerializeField] private float bouciness = 12f;

    private Rigidbody2D deathRb;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        deathRb = deathBody.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayHitAnimation();
            
            PlayerStompBouciness(collision);
        }
    }

    private void DeathBody() // trigger this event in the end of "Hit" Animation
    {
        SpawnDeathBody();
        DeathBodyFall();
        Destroy(this.transform.root.gameObject);
    }

    private void PlayerStompBouciness(Collider2D collision)
    {
        var playerRb = collision.GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(playerRb.velocity.x, bouciness);
    }

    private void SpawnDeathBody()
    {
        var body = Instantiate(deathBody);
        body.transform.position = transform.position;
    }

    private void PlayHitAnimation()
    {
        anim.Play("Hit");
    }

    private void DeathBodyFall()
    {
        deathRb.velocity = new Vector2(deathRb.velocity.x, bodyFallingSpeed);
    } 
}
