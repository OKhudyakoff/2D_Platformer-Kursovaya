using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameOver;
    [SerializeField] private AppManager appManagerPrefab;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        #endregion
    }

    private void Start()
    {
        if (!AppManager.Instance)
        {
            Instantiate(appManagerPrefab);
        }
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        LevelManager.Instance.RestartLevel();
    }
}
