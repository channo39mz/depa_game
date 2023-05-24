using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSkill : Skill
{
    [SerializeField] private Ingredients ingredients;
    public Ingredients Ingredients { get => ingredients; }
}
