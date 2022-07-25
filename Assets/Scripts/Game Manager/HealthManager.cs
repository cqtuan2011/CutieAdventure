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

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            UIManager.Instance.Invoke("OpenLoseMenu", 2f);
        }
    }

    public void AddHeart()
    {
        if (currentHealth >= maxHealth) return;
        currentHealth++;
    }
}
