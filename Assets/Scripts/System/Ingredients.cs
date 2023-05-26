using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredients
{
    [SerializeField] private int coins;
    [SerializeField] private List<LineItem> items;

    public Ingredients(int coins)
    {
        this.coins = coins;
    }

    public void Add(Item item, int quantity)
    {
        items.Add(new LineItem(item, quantity));
    }

    public bool Trade(Ingredients ingredients)
    {
        if (Contain(ingredients))
        {
            ingredients.coins -= coins;
            foreach (LineItem item in items)
            {
                ingredients.GetLineItem(item.Item).Quantity -= GetLineItem(item.Item).Quantity;
            }
            return true;
        }
        return false;
    }

    private bool Contain(Ingredients ingredients)
    {
        foreach (LineItem item in items)
        {
            if (ingredients.coins < coins
                || !ingredients.Contain(item.Item)
                || ingredients.GetLineItem(item.Item).Quantity < GetLineItem(item.Item).Quantity)
            {
                return false;
            }
        }
        return true;
    }

    private bool Contain(Item item)
    {
        if (GetLineItem(item) != null)
        {
            return true;
        }
        return false;
    }

    private LineItem GetLineItem(Item item)
    {
        foreach (LineItem lineItem in items)
        {
            if (lineItem.Item.Equals(item))
            {
                return lineItem;
            }
        }
        return null;
    }

    //for player
    public void AddItemFromPlayer(Item pickupItem){
        for(int i=0;i<items.Count;i++){
            if(items[i].Item.name == pickupItem.name){
                items[i].Quantity++;
                return;
            }
        }
        Add(pickupItem,1);
    }

    public List<LineItem> getListItems(){
        return items;
    }

    public void CoinIncrease(float amount){
        coins += (int)amount;
    }

    public int getCoin(){
        return coins;
    }
    public override string ToString()
    {
        string str = items[0].Item.ItemName + "(" + items[0].Quantity + ")";
        for (int i = 1; i < items.Count; i++)
        {
            str += ", " + items[i].Item.ItemName + "(" + items[i].Quantity + ")";
        }
        return str;
    }
}