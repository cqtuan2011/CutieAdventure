using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private int currentSceneIndex;
    private const string LEVEL_SELECT_SCENE = "";

    private void Awake()
    {
        Instance = this;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevelSelectScene()
    {
        SceneManager.LoadScene(LEVEL_SELECT_SCENE);
    }
}
