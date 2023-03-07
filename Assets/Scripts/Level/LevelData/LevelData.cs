using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelData : ScriptableObject {
    [Header("Items count for finish")]
    public int KiwiCount = 0;
    public int BananaCount = 0;
    public int AppleCount = 0;
} 
