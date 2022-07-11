using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManger : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            PauseGame(); 
            else ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneLoader.Instance.ReloadScene();
    }

    private void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void LoadSettingMenu(string settingMenuName)
    {
        SceneLoader.Instance.LoadSceneName(settingMenuName);
    }

    public void LoadMenu(string mainMenuName)
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadSceneName(mainMenuName);
    }

    public void ExitApplication()
    {
        SceneLoader.Instance.ExitApplication();
    }
}
