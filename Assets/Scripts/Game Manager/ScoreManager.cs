using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "x " + score;
    }
}
