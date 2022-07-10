using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static StarManager Instance;

    public int starAmount { get; set; }

    private int maxAmount = 3;

    [SerializeField] private Image[] starImage;
    [SerializeField] private Color unFilledColor;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        starAmount = 0;

        foreach (Image img in starImage)
        {
            img.color = unFilledColor;
        }
    }
    void Update()
    {
        LoadStarImage();
    }

    private void LoadStarImage()
    {
        if (starAmount > maxAmount) return;

        for (int i = 0; i < starAmount; i++)
        {
            starImage[i].color = new Color(255, 255, 255, 255);
        }
    }
}
