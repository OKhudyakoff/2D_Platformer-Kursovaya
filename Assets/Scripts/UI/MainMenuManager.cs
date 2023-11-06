using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button start_button;
    [SerializeField] private Button exit_button;
    [SerializeField] private AppManager appManagerPrefab;

    private void Start()
    {
        if (AppManager.Instance == null)
        {
            Instantiate(appManagerPrefab);
        }
        start_button.onClick.AddListener(() => LevelManager.Instance.LoadLevelByIndex(2));
        exit_button.onClick.AddListener(() => Application.Quit());
    }
}