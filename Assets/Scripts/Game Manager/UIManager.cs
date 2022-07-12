using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
}
