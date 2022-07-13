using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance { get; private set; }

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayTransitionEffect()
    {
        anim.SetTrigger("End");
    }
}
