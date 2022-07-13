using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseManager : MonoBehaviour
{
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        loseMenu.SetActive(false);
        levelText.text = "LEVEL " + SceneLoader.Instance.GetSceneName();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinCountText();
    }

    private void UpdateCoinCountText()
    {
        coinText.text = "x " + ScoreManager.Instance.score;
    }
}
