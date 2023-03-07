using UnityEngine;
using UnityEngine.UI;

public class Menu_Ui : MonoBehaviour
{
    [SerializeField] private Button start_button;
    [SerializeField] private Button exit_button;
    [SerializeField] private LevelLoader levelLoader;

    private void Awake()
    {
        start_button.onClick.AddListener(() => levelLoader.LoadNextLevel(1));
        exit_button.onClick.AddListener(() => levelLoader.Exit());
    }
}