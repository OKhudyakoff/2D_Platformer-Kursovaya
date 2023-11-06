using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LevelManager.Instance.LoadLevelByIndex(1);
        }
    }
}