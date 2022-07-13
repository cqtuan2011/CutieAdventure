using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Pause Menu")]
    [Space(5)]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PauseManger pauseManager;

    [Space(10)]

    [Header("Win Menu")]
    [Space(5)]
    [SerializeField] private GameObject winMenu;
    [SerializeField] private WinManager winManager;

    [Space(10)]

    [Header("Lose Menu")]
    [Space(5)]
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private LoseManager loseManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        SetTimeScale(1);
    }

    public void LoadLevelSelectScene()
    {
        SetTimeScale(1);
        
        SceneLoader.Instance.LoadLevelSelectScene();
    }

    public void LoadNextLevel()
    {
        SetTimeScale(1);

        SceneLoader.Instance.LoadNextScene();
    }
    public void RestartGame()
    {
        SetTimeScale(1);

        SceneLoader.Instance.ReloadScene();
    }
    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void LoadSettingMenu(string settingMenuName)
    {
        SetTimeScale(1);
        SceneLoader.Instance.LoadSceneName(settingMenuName);
    }

    public void LoadMenu(string mainMenuName)
    {
        SetTimeScale(1);
        SceneLoader.Instance.LoadSceneName(mainMenuName);
    }

    public void OpenWinMenu()
    {
        SetTimeScale(0);
        winMenu.SetActive(true);

        pauseManager.enabled = false;
    }

    public void OpenLoseMenu()
    {
        SetTimeScale(0);
        loseMenu.SetActive(true);

        pauseManager.enabled = false;
    }
}
