using System;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    protected virtual void Collect()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}