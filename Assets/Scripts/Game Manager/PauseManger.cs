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
        Debug.Log("pauseManager PauseGame function");
        pauseMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
