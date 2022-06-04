using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    private AIOverlapDetector detector;
    private Animator anim;

    private void Awake()
    {
        detector = GetComponent<AIOverlapDetector>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetBool("playerInArea", detector.playerInArea);
    }

    void Shoot() // Call by the event in Attack animation
    {
        int direction() // Check bullet direction by flipX
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                return 1;
            } else
            {
                return -1;
            }
        }
        GameObject newBullet =  Instantiate(bullet, firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction(), 0f);
    }

}
