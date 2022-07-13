using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;
    public int currentHealth { get; set; }
    
    [SerializeField] public int maxHealth;

    [Header("For UI")]
    public Image[] heartSlot;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool playerDie = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        UpdateHeartImage();
        HealthCheck();
        PlayerDie();
    }

    private void UpdateHeartImage()
    {
        foreach (Image img in heartSlot)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < currentHealth; i++)
        {
            heartSlot[i].sprite = fullHeart;
        }
    }

    private void HealthCheck()
    {
        if (currentHealth <= 0)
        {
            playerDie = true;
            return;
        }
    }

    private void PlayerDie()
    {
        if (playerDie)
        {
            UIManager.Instance.Invoke("OpenLoseMenu", 0.35f);
            playerDie = false;
        }
    }
}
