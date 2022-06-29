using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingBehaviour : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    private AIOverlapDetector detector;
    private Animator anim;

    //private delegate void OnFacingPlayer();
    //private OnFacingPlayer onFacingPlayer;

    [SerializeField] private bool trunkMode;
    [SerializeField] private Transform playerToFollow;

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
        TrunkMode();
    }

    void Shoot() // Call by the event in Attack animation
    {
        int direction() // Check bullet direction by flipX
        {
            if (transform.localScale.x == 1) // enemy facing left
            {
                return -1;
            }
            else  // enemy facing left
            {
                return 1;
            }
        }
        GameObject newBullet =  Instantiate(bullet, firePoint.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction(), 0f);
    }

    private void TrunkMode()
    {
        if (trunkMode && detector.playerInArea)
        {
            GetComponent<WaypointFollower>().enabled = false;

            //onFacingPlayer += FacingPlayerDirection;
            //onFacingPlayer();

            FacingPlayerDirection();
        } else
        {
            if (GetComponent<WaypointFollower>() != null)
            {
                GetComponent<WaypointFollower>().enabled = true;
                //onFacingPlayer -= FacingPlayerDirection;
            }
        }
    }

    private void FacingPlayerDirection()
    {
        Vector3 scale = transform.localScale;
        if (transform.position.x < playerToFollow.position.x)
        {
            scale.x = -1;
        }
        else scale.x = 1;

        transform.localScale = scale;
    }
}
