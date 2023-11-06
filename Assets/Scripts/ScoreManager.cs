using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private int targetFruitsCount = 0;
    public int TargetFruitsCount
    {
        get
        {
            if (targetFruitsCount == 0)
            {
                targetFruitsCount = FindObjectsOfType<CollectibleFruitItem>().Length;
            }

            return targetFruitsCount;
        }
    }
    public int CurrentFruitsCount = 0;

    private void OnEnable()
    {
        CollectibleFruitItem.OnFruitCollected += IncrementCurrentScore;
    }

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
        
        CurrentFruitsCount = 0;
    }

    private void IncrementCurrentScore()
    {
        CurrentFruitsCount += 1;
        GameUIManager.Instance.UpdateScore();
    }
}