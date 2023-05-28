using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    public string ItemName { get => itemName; }
    [SerializeField] private string description;
    public string Description { get => description; }
    public Sprite image;
}
