using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatalog : MonoBehaviour
{
    private Dictionary<string, Item> itemList = new Dictionary<string, Item>();

    private void Awake()
    {
        Item[] items = GetComponentsInChildren<Item>(true);
        foreach (Item item in items)
        {
            itemList.Add(item.ItemName, item);
        }
    }

    public Item GetItem(string name)
    {
        return itemList[name];
    }
}
