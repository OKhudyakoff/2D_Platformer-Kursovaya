using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other !.CompareTag("Player")) return;
        if (IsCanFinish())
        {
            LevelManager.Instance.LoadNextLevel();
        }
        else
        {
            GameUIManager.Instance.ShowFinishWarning();
        }
    }

    public bool IsCanFinish()
    {
        return ScoreManager.Instance.CurrentFruitsCount == ScoreManager.Instance.TargetFruitsCount;
    }
}