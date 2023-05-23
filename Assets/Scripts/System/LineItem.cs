using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LineItem
{
    [SerializeField] private Item item;
    [SerializeField] private int quantity;

    public override string ToString()
    {
        return item.ItemName + " : " + quantity;
    }
}
