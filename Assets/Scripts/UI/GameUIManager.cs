using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance { get; private set; }
    [SerializeField] private TMP_Text ScoreTMP;
    [SerializeField] private Animation finishWarningTextAnimation;

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
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (ScoreTMP)
        {
            ScoreTMP.text = "Фрукты: " + ScoreManager.Instance.CurrentFruitsCount + "/" + ScoreManager.Instance.TargetFruitsCount;
        }
    }

    public void ShowFinishWarning()
    {
        finishWarningTextAnimation.Play(); }
}
