using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemLife : CollectibleItemBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddLifes();
    }
}
