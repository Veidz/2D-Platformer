using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemBase : MonoBehaviour
{
    public string compareTag = "Player";

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
}
