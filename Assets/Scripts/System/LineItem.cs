using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LineItem
{
    [SerializeField] private Item item;
    public Item Item { get => item; }
    [SerializeField] private int quantity;
    public int Quantity
    {
        get => quantity;
        set => quantity = value;
    }

    public LineItem(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public void Change(int quantity)
    {
        this.quantity += quantity;
    }

    public override string ToString()
    {
        return item.ItemName + "(" + quantity + ")";
    }
}
