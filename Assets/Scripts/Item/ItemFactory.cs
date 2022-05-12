using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemFactory
{
    static ItemSO[] allItems = Resources.LoadAll<ItemSO>("Items");

    public static ItemSO[] GetRandomInventory()
    {
        ItemSO[] items = new ItemSO[Random.Range(1, 3)];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = GetRandomItem();
        }
        return items;
    }

    public static ItemSO GetRandomItem()
    {
        ItemSO newItem = ItemSO.CreateInstance(allItems[Random.Range(0, allItems.Length)]);
        newItem.durability = Random.Range(20, 101);
        return newItem;
    }
}
