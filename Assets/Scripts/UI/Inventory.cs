using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform Parent;
    [SerializeField] ItemSlot[] itemSlots;

    void Start(){
        this.enabled = false;
    }

    private void OnValidate(){
        if(Parent != null){
            itemSlots = Parent.GetComponentsInChildren<ItemSlot>();
        }

        Refresh();
    }
    public void AddItems(Item pickedItem){
        for(int i=0;i<itemSlots.Length;i++){
            if(itemSlots[i].Item == null) {
                itemSlots[i].Quantity++;
                items.Add(pickedItem);
                break;
            }
            else if(itemSlots[i].Item.GetItemName().Equals(pickedItem.GetItemName())){
                itemSlots[i].Quantity++;
                Destroy(pickedItem.gameObject);
                break;
            }
        }
        Refresh();
    }
    // public bool CanCraft(Item itemUse){
    //     for(int i=0;i<itemSlots.Length;i++){

    //     }
    // }
    private void Refresh(){
        int i=0;
        for(;i<items.Count && i<itemSlots.Length;i++){
            itemSlots[i].Item = items[i];
        }
        for(;i<itemSlots.Length;i++){
            itemSlots[i].Item = null;
        }
    }


}