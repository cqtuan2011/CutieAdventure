using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTrapTimer : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float startAfterSeconds;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.enabled = false;

        StartCoroutine(StartAnimator());
    }

    IEnumerator StartAnimator()
    {
        yield return new WaitForSeconds(startAfterSeconds);

        anim.enabled = true;
    }
}
