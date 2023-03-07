using TMPro;
using UnityEngine;

public class Item_Ui : MonoBehaviour
{
    [SerializeField] private TMP_Text count;
    [SerializeField] private GameObject doneImage;

    public void UpdateInfo(int count)
    {
        this.count.SetText(count.ToString());
    }

    public void SetDone()
    {
        count.gameObject.SetActive(false);
        doneImage.SetActive(true);
    }
}