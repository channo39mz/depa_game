using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    public Sprite image;
    public string Description { get; }

    public string GetItemName(){
        return itemName;
    }
}