using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropRate
{
    [SerializeField] private Item[] group;
    public Item[] Group { get => group; }
    [SerializeField] private float rate;
    public float Rate { get => rate; }
    [SerializeField] private int quantity;
    public int Quantity { get => quantity; }
}