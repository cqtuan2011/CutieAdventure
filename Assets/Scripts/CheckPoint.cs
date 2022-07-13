using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private CheckPointType checkPointType;
    [SerializeField] private GameObject winMenu;
    
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("isTouched");

            switch (checkPointType)
            {
                case CheckPointType.StartPoint:
                    break;
                case CheckPointType.EndPoint:
                    UIManager.Instance.OpenWinMenu();
                    break;
            }
        }
    }

    private enum CheckPointType
    {
        StartPoint,
        EndPoint,
    }
}
