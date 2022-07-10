using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
}
