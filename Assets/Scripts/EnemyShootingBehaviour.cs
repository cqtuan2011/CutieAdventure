using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingBehaviour : MonoBehaviour
{
    [SerializeField] private ShootingType shootingType;

    [SerializeField] float shootSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] bool lookAtPlayer;

    private AIOverlapDetector detector;
    private Animator anim;

    //private delegate void OnFacingPlayer();
    //private OnFacingPlayer onFacingPlayer;

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
        GameObject newBullet =  Instantiate(bullet, firePoint.position, Quaternion.identity);

        if (shootingType == ShootingType.Horizontal)
        {
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Direction(), 0f);
        } else
        {
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -shootSpeed);
        }
    }

    private void TrunkMode()
    {
        if (shootingType == ShootingType.Horizontal && detector.playerInArea)
        {

            DisableWaypointFollower();

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
        if (lookAtPlayer)
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

    private void DisableWaypointFollower()
    {
        if (GetComponent <WaypointFollower>() != null)
        GetComponent<WaypointFollower>().enabled = false;
    }

    public int Direction()
    {
        if (transform.localScale.x == 1) // enemy facing left
        {
            return -1;
        }
        else  // enemy facing right
        {
            return 1;
        }
    }

    private enum ShootingType
    {
        Horizontal,
        Vertical,
    }
}
