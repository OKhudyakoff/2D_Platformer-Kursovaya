using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private Animation target_UI_animation;

    [SerializeField]
    private int nextLevelIndex = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other == LevelManager.Instance.CurrentPlayer().Player_Collider)
        {
            if(CanFinish())
            {
                LevelManager.Instance.levelLoader.LoadNextLevel(nextLevelIndex);
            }
            else{
                target_UI_animation.Play();
            }
        }
    }

    public bool CanFinish()
    {
        return(LevelManager.Instance.itemCollector.appleCollected &&
        LevelManager.Instance.itemCollector.bananaCollected &&
        LevelManager.Instance.itemCollector.kiwiCollected);
    }
}
