using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int fireTime = 3;
    [SerializeField] private float timeBeforeNextAttack = 3f;

    private Animator anim;
    private float timer;
    private int actionRepeatTime = 0;
    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    void Start()
    {
        timer = timeBeforeNextAttack;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            anim.SetTrigger("Attack");
            timer = timeBeforeNextAttack;
        }
    }

    private void Shoot() // this function is triggered in the attack animation
    {
        GameObject bullet = Instantiate(bulletPref, firePoint.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -bulletSpeed);
    }

    private void CheckActionRepeat() // this function is trigger in the end of attack animation to check the repeat time of it
    {
        actionRepeatTime++;
        if (actionRepeatTime >= fireTime)
        {
            actionRepeatTime = 0;
            return;
        }
        anim.SetTrigger("Attack");
    }
}
