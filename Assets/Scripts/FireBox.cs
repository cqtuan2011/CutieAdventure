using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBox : MonoBehaviour
{
    private bool isOn;
    private bool canHit;
    private Animator anim;
    public float fireTime = 3f;
    public float delayBeforeFire = 2f;

    [SerializeField] private PlayerController player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        canHit = true;
    }
    private void Update()
    {
        UpdateAnimation();
        StartCoroutine(TurnOffFireAfter3Sec());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canHit && collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("IsHit");
            canHit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.PlayerGetHit();
        }
    }

    private void UpdateAnimation()
    {
        anim.SetBool("isOn", isOn);
    }

    IEnumerator FireAfter2Seconds() // call by event in "Hit" animation
    {
        yield return new WaitForSeconds(delayBeforeFire);

        isOn = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }

    IEnumerator TurnOffFireAfter3Sec()
    {
        if (isOn)
        {
            yield return new WaitForSeconds(fireTime);

            isOn = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            canHit = true;
        }
    }
}
