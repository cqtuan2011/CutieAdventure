using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;

    [Space(10)]

    [Header("Level UI")]
    [SerializeField] private TextMeshProUGUI levelText;

    [Space(10)]

    [Header("Coin UI")]
    [SerializeField] private TextMeshProUGUI coinText;

    [Space(10)]

    [Header("Stars UI")]
    [SerializeField] private Color unFilledColor;
    [SerializeField] private Color filledColor;
    [SerializeField] private Image[] collectedStar;

    void Start()
    {
        winMenu.SetActive(false);
        levelText.text = "LEVEL " + SceneLoader.Instance.GetSceneName();
    }

    private void Update()
    {
        UpdateStar();
        UpdateCoinCountText();
    }

    private void UpdateStar()
    {
        foreach (var star in collectedStar)
        {
            star.color = unFilledColor;
        }

        for (int i = 0; i < StarManager.Instance.starAmount; i++)
        {
            collectedStar[i].color = filledColor;
        }
    }

    private void UpdateCoinCountText()
    {
        coinText.text = "x " + ScoreManager.Instance.score;
    }
}
