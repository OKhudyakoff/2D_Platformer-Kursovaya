using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public enum ItemType
    {
        Apple,
        Kiwi,
        Banana
    }

    private bool collected = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == LevelManager.Instance.CurrentPlayer().Player_Collider && !collected)
        {
            StartCoroutine(CollectItem());
        }
    }

    private IEnumerator CollectItem()
    {
        collected = true;
        animator.SetTrigger("Collect");
        LevelManager.Instance.itemCollector.ItemCollected(itemType);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}