using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform Parent;
    [SerializeField] ItemSlot[] itemSlots;
    public Ingredients playerIngredients;
    void Start(){
        // this.enabled = false;
    }
    void Update(){
        Refresh();
    }
    private void OnValidate(){
        if(Parent != null){
            itemSlots = Parent.GetComponentsInChildren<ItemSlot>();
        }
    }
    public void AddItems(Item pickedItem){
        playerIngredients.AddItemFromPlayer(pickedItem);

        Refresh();
    }
    public void addCoin(float amount){
        playerIngredients.CoinIncrease(amount);
    }
    private void Refresh(){
        int i=0;
        List<LineItem> tmpList = playerIngredients.getListItems();
        for(;i < tmpList.Count && i<itemSlots.Length;i++){
            itemSlots[i].Item = tmpList[i].Item;
            itemSlots[i].Quantity = tmpList[i].Quantity;
        }
        for(;i<itemSlots.Length;i++){
            itemSlots[i].Item = null;
        }
    }


}