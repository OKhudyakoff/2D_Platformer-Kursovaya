using System;
using System.Collections;
using UnityEngine;


public class CollectibleFruitItem : CollectibleItem
{
    private Animator animator;
    public static Action OnFruitCollected;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void Collect()
    {
        StartCoroutine(CollectItem());
    }

    private IEnumerator CollectItem()
    {
        if (animator != null)
        {
            animator.SetTrigger("Collect");
        }

        OnFruitCollected?.Invoke();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}