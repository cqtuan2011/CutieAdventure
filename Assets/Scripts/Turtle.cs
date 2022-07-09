using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    [SerializeField] private float idleTime = 3.5f;
    [SerializeField] private float spikeTime = 5f;
    [SerializeField] private GameObject spikeCollider;

    private bool isSpikeIn;
    private Animator anim;
    private float idleTimeCount = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        isSpikeIn = true;
        idleTimeCount = idleTime;
    }

    void Update()
    {
        IdleTimer();
        SetSpikeCollider();
    }

    private void IdleTimer()
    {
        if (isSpikeIn)
        {
            idleTimeCount -= Time.deltaTime;

            if (idleTimeCount <= 0)
            {
                anim.Play("SpikeOut");

                DeactiveDeathTriggerCollider();
                StartCoroutine(SpikeIn());

                isSpikeIn = false;
            }
        }
    }

    private void SetSpikeCollider()
    {
        spikeCollider.SetActive(!isSpikeIn);
    }

    private void DeactiveDeathTriggerCollider()
    {
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    }
    private void ActiveDeathTriggerCollider()
    {
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = true;
        }
    }

    IEnumerator SpikeIn()
    {
        yield return new WaitForSeconds(spikeTime);

        anim.Play("SpikeIn");

        ActiveDeathTriggerCollider();

        idleTimeCount = idleTime;
        isSpikeIn = true;
    }
}
