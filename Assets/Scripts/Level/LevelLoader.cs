using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 0.5f;

    public void LoadNextLevel(int levelIndex)
    {
        StartCoroutine(StartSceneTransition(levelIndex));
    }

    private void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void RestartLevel()
    {
        StartCoroutine(StartSceneTransition(SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator StartSceneTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        LoadLevel(levelIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}