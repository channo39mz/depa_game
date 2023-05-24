using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCatalog : MonoBehaviour
{
    private Dictionary<string, Skill> skillList = new Dictionary<string, Skill>();
    private Dictionary<string, Ingredients> ingredList = new Dictionary<string, Ingredients>();

    private void Start()
    {
        CraftingSkill[] skills = GetComponentsInChildren<CraftingSkill>(true);
        foreach (var skill in skills)
        {
            skillList.TryAdd(skill.SkillName, skill);
            ingredList.TryAdd(skill.SkillName, skill.Ingredients);
        }
    }

    public Skill GetSkill(string name)
    {
        return skillList[name];
    }

    public Ingredients GetIngredients(string name)
    {
        return ingredList[name];
    }

    public void showCatalog()
    {
        foreach (string name in skillList.Keys)
        {
            Debug.Log(name);
            GetIngredients(name).ShowIngredients();
        }
    }
}
