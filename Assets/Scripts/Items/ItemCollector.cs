using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public bool appleCollected { get; private set; }
    public bool kiwiCollected { get; private set; }
    public bool bananaCollected { get; private set; }

    #region UI

    [Header("Items_UI")] [SerializeField] private Item_Ui banana_UI;
    [SerializeField] private Item_Ui apple_UI;
    [SerializeField] private Item_Ui kiwi_UI;

    #endregion

    public void ItemCollected(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Apple:
                appleCollected = true;
                apple_UI.SetDone();
                break;
            case Item.ItemType.Kiwi:
                kiwiCollected = true;
                kiwi_UI.SetDone();
                break;
            case Item.ItemType.Banana:
                bananaCollected = true;
                banana_UI.SetDone();
                break;
            default:
                break;
        }
    }
}