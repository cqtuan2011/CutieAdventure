using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private int currentSceneIndex;

    [SerializeField] private float transitionDelayTime = 0.4f;
    [SerializeField] private GameObject sceneTransition;

    private void Awake()
    {
        Instance = this;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        sceneTransition.SetActive(true);
    }
    public void ReloadScene()
    {
        StartCoroutine(LoadSceneIndex(currentSceneIndex));
    }

    public void LoadSceneName(string sceneName)
    {
        StartCoroutine(LoadSceneString(sceneName));
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneIndex(currentSceneIndex + 1));
    }

    public void ExitApplication()
    {
        StartCoroutine(ExitGame());
    }

    public string GetSceneName() // for UI update menu
    {
        return SceneManager.GetActiveScene().name;
    }

    private IEnumerator LoadSceneIndex (int levelIndex)
    {
        SceneTransition.Instance.PlayTransitionEffect();

        yield return new WaitForSeconds(transitionDelayTime);

        SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator LoadSceneString(string sceneName)
    {
        SceneTransition.Instance.PlayTransitionEffect();

        yield return new WaitForSeconds(transitionDelayTime);

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator ExitGame()
    {
        SceneTransition.Instance.PlayTransitionEffect();

        yield return new WaitForSeconds(transitionDelayTime);

        Application.Quit();
    }
}
