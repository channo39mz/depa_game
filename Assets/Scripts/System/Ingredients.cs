using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredients
{
    [SerializeField] private LineItem[] items;

    public void ShowIngredients()
    {
        foreach (LineItem item in items)
        {
            Debug.Log(" - " + item);
        }
    }
}
