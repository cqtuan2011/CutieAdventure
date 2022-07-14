using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadLevelStar : MonoBehaviour
{
    [SerializeField] private Image[] starImg;

    [SerializeField] private Color unfilledColor;

    public int collectedStar;

    private void Start()
    {
        PrepareStar();
    }

    private void Update()
    {
        UpdateCollectedStar();
    }

    private void PrepareStar()
    {
        foreach (var img in starImg)
        {
            img.color = unfilledColor;
        }
    }

    private void UpdateCollectedStar()
    {
        for (int i = 0; i < collectedStar; i++)
        {
            starImg[i].color = new Color(255, 255, 255, 255);
        }
    }
}
