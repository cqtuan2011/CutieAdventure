using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;
    [SerializeField] private TextMeshProUGUI levelText;

    void Start()
    {
        winMenu.SetActive(false);
        levelText.text = "LEVEL " + SceneLoader.Instance.GetSceneName();
    }
}
