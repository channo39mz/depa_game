using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shop
{
    [SerializeField] private SkillCatalog catalog;
    public CraftingSkill[] Order { get; private set; }

    public void NewOrder(int n)
    {
        Order = catalog.Choose(3).ToArray();
    }

    public Skill BuySkill(int n, Ingredients ingredients)
    {
        if (hasOrder(n) && Order[n - 1].Ingredients.Trade(ingredients))
        {
            Skill tmp = Order[n - 1];
            Order[n - 1] = null;
            return tmp;
        }
        return null;
    }

    private bool hasOrder(int n)
    {
        if (Order[n - 1] != null)
        {
            return true;
        }
        return false;
    }
}
