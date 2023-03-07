using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;
    public static LevelManager Instance { get; private set; }
    public LevelLoader levelLoader { get; private set; }
    public ItemCollector itemCollector { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        itemCollector = GetComponent<ItemCollector>();
    }

    public Player CurrentPlayer()
    {
        return player;
    }
}