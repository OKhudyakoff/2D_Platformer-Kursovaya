using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 0.5f;
    private int[] levelBuildIndexes; // Индексы сцен, которые являются уровнями

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeLevels();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            StartCoroutine(EndSceneTransition());
        }
    }

    private void InitializeLevels()
    {
        levelBuildIndexes = new int[] {2, 3}; // Индексы уровней в Build Settings
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = System.Array.IndexOf(levelBuildIndexes, currentSceneIndex) + 1;
        if (nextLevelIndex < levelBuildIndexes.Length)
        {
            // Загрузить следующий уровень
            StartCoroutine(StartSceneTransition(levelBuildIndexes[nextLevelIndex]));
        }
        else
        {
            // Если уровни закончились, вернуться в главное меню
            StartCoroutine(StartSceneTransition(1));
        }
    }
    
    public void LoadLevelByIndex(int levelIndex)
    {
        if (levelIndex > 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(StartSceneTransition(levelIndex));
        }
        else
        {
            Debug.LogError("Trying to load level index out of bounds");
        }
    }

    public void RestartLevel()
    {
        StartCoroutine(StartSceneTransition(SceneManager.GetActiveScene().buildIndex));
    }

    //Анимации перехода между уровнями
    private IEnumerator StartSceneTransition(int sceneIndex)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator EndSceneTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}