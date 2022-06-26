using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt lifes;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        lifes.value = 3;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddLifes(int amount = 1)
    {
        lifes.value += amount;
    }
}
