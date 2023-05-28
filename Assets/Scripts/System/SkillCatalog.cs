using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillCatalog
{
    [SerializeField] private CraftingSkill[] skills;
    public CraftingSkill[] Skills { get => skills; }

    public List<CraftingSkill> Choose(int c)
    {
        List<int> order = Choose(skills.Length, c);
        List<CraftingSkill> choice = new List<CraftingSkill>();
        for (int i = 0; i < c; i++)
        {
            choice.Add(skills[order[i]]);
        }
        return choice;
    }

    private List<int> Choose(int n, int c)
    {
        // [0, 1, 2, 3, ... , n - 1]
        List<int> order = new List<int>();
        for (int i = 0; i < n; i++)
        {
            order.Add(i);
        }
        
        List<int> random = new List<int>();
        for (int i = n; i >= (n + 1) - c; i--)
        {
            int choose = Random.Range(0, i);
            random.Add(order[choose]);
            order.RemoveAt(choose);
        }
        return random;
    }

    public void ShowCatalog()
    {
        foreach (CraftingSkill skill in skills)
        {
            Debug.Log(skill.SkillName + " : " + skill.Ingredients);
        }
    }
}
