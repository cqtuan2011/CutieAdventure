using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Collected");

            switch (itemType)
            {
                case ItemType.AddScore:
                    ScoreManager.Instance.AddScore();
                    break;

                case ItemType.AddHeart:
                    HealthManager.Instance.currentHealth++;
                    break;

                case ItemType.AddStar:
                    StarManager.Instance.starAmount++;
                    break;
            }

        }
    }

    private void DestroyItem() // trigger this event in "collected" animation
    {
        Destroy(gameObject);
    }

    private enum ItemType
    {
        AddScore,
        AddHeart,
        AddStar
    }
}
